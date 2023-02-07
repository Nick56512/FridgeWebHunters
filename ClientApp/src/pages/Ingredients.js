import DropDownList from '../atoms/Drop-Down-List'
import { useState, useEffect } from 'react'
import Loading from '../atoms/Loading'
import IngredientCard from '../organisms/IngredientCard'

function Ingredients(){

	const [filter, setFilter] = useState('all')
	const [ingredients, setIngredients] = useState([])
	const [filtered, setFiltered] = useState([])
	const [isLoading, setLoading] = useState(false)

	useEffect(() => {
			getIngredients()
	}, [])

	async function getIngredients(){
		setLoading(true)
		
		setTimeout(async () => {
			await fetch('https://dummyjson.com/products')
			.then(res => res.json())
			.then(data => {
				setIngredients(data.products.slice(0, 20))
				setFiltered(data.products.slice(0, 20))
			})
			.catch(e => console.log(e))
			setLoading(false)
		}, 300)

	}

	function filterInredients(filter){
		setFilter(filter)
		if (filter === 'all'){
			setFiltered([...ingredients])
		}
		else{
			setFiltered([...ingredients.filter(item => item.category === filter)])
		}
	}

	return(
		<>
			<img className="bg__page" src={require("../assets/bg.jpg")}></img>
			<div className="container">
				<h2 className='main__title'>Мій холодильник</h2>
				<div className='ingridients__page'>
					<div className='page__tabs'>
						<DropDownList
							value={filter}
							onChange={filterInredients}
							options={[
								{value: 'all', name: "Усі"},
								{value: 'laptops', name: "Молочні"},
								{value: 'smartphones', name: 'Хлібобулочні'},
								{value: 'vegetables', name: "М'ясні"},
								{value: 'fruits', name: "Алкогольні"},
								{value: 'tert', name: "Ковбасні"},
								{value: '3tgftde', name: "Солодощі"},
								{value: '3tgfrde', name: "Овочі"},
								{value: '3tgfdse', name: "Фрукти"}
							]}
						/>
						<div>
							<button className='tabs__button'>Що я можу приготувати?</button>
						</div>
					</div>
					<div className='page__ingridients'>
						{isLoading 
						? 
						<Loading></Loading>
						:
						filtered.map(ingredient => (
							<IngredientCard
								key={ingredient.id}
								title={ingredient.title}
								image={ingredient.thumbnail}
								category={ingredient.category}
							/>
						))
						}
					</div>
				</div>
			</div>
		</>
	)
}

export default Ingredients