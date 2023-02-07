import { useState, useEffect, useMemo } from "react"
import { Link } from "react-router-dom"
import Loading from "../atoms/Loading"
import RecipeCard from "../organisms/RecipeCard"
import useInput from "../hooks/useInput"

function Recipes(){

	const [recipes, setRecipes] = useState([])
	const [isLoading, setLoading] = useState(false)
	const [isDiff, setIsDiff] = useState('yes')
	
	const searchQuery = useInput('')

	useEffect(() => {
		getRecipes()
	}, [])

	function changeSort(){
		if(isDiff == 'yes') setIsDiff('no')
		else setIsDiff('yes')
	}

	const sortedPosts = useMemo(() => {
			if(isDiff == 'yes'){
				return [...recipes.sort((item1, item2) => item1.id - item2.id)]
			}
			else{
				return [...recipes.sort((item1, item2) => item2.id - item1.id)]
			}
	}, [recipes, isDiff])

	const sortedAndSearched = useMemo(() => {
		return sortedPosts.filter(item => item.title.toLowerCase().includes(searchQuery.value.toLowerCase()))
	}, [searchQuery, sortedPosts])
		


	async function getRecipes(){
			setLoading(true)
			setTimeout(async () => {
				await fetch('https://jsonplaceholder.typicode.com/photos')
				.then(res => res.json())
				.then(data => data.slice(0, 50))
				.then(slicedData => setRecipes(slicedData))
				.catch(e => console.log(e))
				setLoading(false)
			}, 300)
		}

	return(
		<div>
			<img className="bg__page" src={require("../assets/bg.jpg")}></img>
			<div className="container">

				<div className="recipes__block">
					<div className="recipes__title">Рецепти</div>
					<div className="button__block">
						<button className="button__all">Всі</button>
						<button className="button__my">Мої</button>
						{isDiff === 'yes'
						?<button onClick={changeSort} className="button__diff">Більш складні</button>
						:<button onClick={changeSort} className="button__diff">Менш складні</button>
						}
						
					</div>
					<div className="input__block">
						<input value={searchQuery.value} onChange={searchQuery.onChange} placeholder="Пошук рецепту.." type="text" />
					</div>
				</div>
				<div className="page__recipes">
					{isLoading 
					? <Loading></Loading>
					:
					sortedAndSearched 
						?
						sortedAndSearched.map(recipe => (
							<Link key={recipe.id} to={`/recipes/${recipe.id}`}>
								<RecipeCard id={recipe.id} title={recipe.title} src={recipe.url}></RecipeCard>
							</Link>
							))
						: 
						<div className="noRecipes">Рецепти не знайдені</div>
					}
					
				</div>
			</div>
		</div>
	)
}

export default Recipes