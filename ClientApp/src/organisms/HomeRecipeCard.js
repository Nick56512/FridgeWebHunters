import "../styles/css/index.css"

function HomeRecipeCard(props){

	return(
		<div className="recipe__card">
			<div className="card__img">
				<img className="main__img" alt={props.title} src={props.src}></img>
					<div className="img__title">
						<div>{props.title}</div>
						<div className="description">{props.title}</div>
						<div className="diff">Складність: {props.id*10} хв.</div>
					</div>
			</div>
		</div>
	)
}

export default HomeRecipeCard