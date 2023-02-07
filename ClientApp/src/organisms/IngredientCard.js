import "../styles/css/index.css"

function IngredientCard(props){

	return(
		<div className="ingridient__card">
			<div className="card__img">
				<img className="main__img" alt={props.title} src={props.image}></img>
				<div className="img__title">{props.title}</div>
			</div>
			<div className="card__block">
				<div>10</div>
				<div className="category">Кат: 1</div>
			</div>
		</div>
	)
}

export default IngredientCard