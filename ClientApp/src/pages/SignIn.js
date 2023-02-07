import MyNavLink from "../atoms/MyNavLink"
import "../styles/css/index.css"
import Button from "../atoms/SignButton"
import useInput from "../hooks/useInput"
import { useState } from "react"
import { useLocation, useNavigate } from "react-router-dom"
import { useStateContext } from "../context/context"
import ErrorModal from "../organisms/ErrorModal"

function SignIn(){

	const {isAuth, setIsAuth, setName, setLastName} = useStateContext();

	const location = useLocation()
	const navigate = useNavigate()

	const fromPage = location.state?.from?.pathname || '/'

	const [modal, setModal] = useState(false)
	const [error, setError] = useState([])

	const inputEmail = useInput('')
	const inputPassword = useInput('')

	async function Login(){
		let userData = {
			"email": inputEmail.value,
			"password": inputPassword.value
		}
			let response = await fetch('https://fridgewebappwebhunters.azurewebsites.net/login', {
			method: 'POST',
			headers: {
			'Content-Type': 'application/json'},
			body: JSON.stringify(userData)
			})
			
			if(response.status!==400){
				response.json().then(res=>{
				sessionStorage.setItem('userData',JSON.stringify(res))
				sessionStorage.setItem('access_token',res.access_token);
				setName(res.name)
				setLastName(res.lastname)
				setIsAuth(true)
				navigate('/ingredients')
			})}
			if(response.status == 400){
				setError(['Неправильні дані або такого користувача не існує!'])
				setModal(true)
			}
			
	}

	return(
	<div>
		<img className="bg__page" src={require("../assets/signin_bg.jpg")}></img>
		<div className="container relative">
			<div className="modal__signup">
				<h2 className="title__signup">Вхід</h2>
				<div className="signup__flex">
					<input 
					   autoFocus
					   type="text"
						value={inputEmail.value} 
						onChange={inputEmail.onChange} 
						className="Input Input__full" 
						placeholder="Електронна пошта">
					</input>
					<input 
						value={inputPassword.value} 
						onChange={inputPassword.onChange} 
						className="Input Input__full" 
						placeholder="Пароль" 
						type={'password'}>
					</input>
				</div>
				<div className="signup__footer">
					<div className="text">
						<p>Ще нема аккаунта?</p>
						<MyNavLink to={`/SignUp`}>Зареєструйтеся!</MyNavLink>
					</div>
					<div>
						<Button onClick={Login}>Готово!</Button>
					</div>
				</div>
			</div>
		</div>
		<ErrorModal error = {error} setModal={setModal} modal={modal}></ErrorModal>
	</div>
	)
}

export default SignIn