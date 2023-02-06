import { useState, useEffect } from "react"
import { Link } from "react-router-dom"
import Loading from "../atoms/Loading"
import RecipeCard from "../organisms/RecipeCard"

function Recipes(){

	const [recipes, setRecipes] = useState([])
	const [isLoading, setLoading] = useState(false)

	useEffect(() => {
		getRecipes()
	}, [])

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
		<div className="container">
			<h2 className="main__title">Рецепти</h2>
			<div className="page__recipes">
				{isLoading 
				? <Loading></Loading>
				:
				recipes.map(recipe => (
					<Link to={`/recipes/${recipe.id}`}>
						<RecipeCard key={recipe.id} title={recipe.title} src={recipe.url}></RecipeCard>
					</Link>
					))
				}
			</div>
		</div>
	)
}

export default Recipes