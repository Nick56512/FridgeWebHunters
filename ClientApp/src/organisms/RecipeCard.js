import "../styles/css/index.css"

function RecipeCard(props){

	return(
		<div className="recipe__card">
			<div className="card__img">
				<img className="main__img" alt={props.title} src={props.src}></img>
				<div className="img__title">{props.title}</div>
			</div>
			<div className="card__block">
				<div>10</div>
			</div>
		</div>
	)
}

export default RecipeCard