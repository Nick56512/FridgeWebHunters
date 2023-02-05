import { useParams } from "react-router-dom"
import { useState, useEffect } from "react"

function RecipePage(){

	const {id} = useParams()
	const [post, setPost] = useState(null)

	useEffect(() => {
		fetch(`https://jsonplaceholder.typicode.com/photos/${id}`)
		.then(res => res.json())
		.then(data => setPost(data))
	}, [id])

	return(
		<div className="container">
		{post 
		? 
			<>
				<h2>{post.title}</h2>
				<img src={post.url}></img>
				<div>Сложность:</div>
				<div>Продукты, нужные для приготовления:</div>
			</>
		:
		null
		}
		</div>
	)
}

export default RecipePage