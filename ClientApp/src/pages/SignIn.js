import MyNavLink from "../atoms/MyNavLink"
import "../styles/css/index.css"
import Button from "../atoms/SignButton"
import useInput from "../hooks/useInput"
import { useState } from "react"

function SignIn(){

	const [modal, setModal] = useState(false)

	const inputEmail = useInput('')
	const inputPassword = useInput('')

	let errors = []

	return(
	<div>
		<img className="bg__page" src={require("../assets/signin_bg.jpg")}></img>
		<div className="container relative">
			<div className="modal__signup">
				<h2 className="title__signup">Вхід</h2>
				<div className="signup__flex">
					<input 
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
						<Button>Готово!</Button>
					</div>
				</div>
			</div>
		</div>
		<div className={`${(modal) ? 'overlay animated show' : 'overlay animated hide'}`} onClick={() => setModal(false)}>
			<div className="errors">
					<ol>
						{errors 
							?
							errors.map(item => (
								<li key={item}>{item}</li>
							))
							:
							null
						}
					</ol>
				</div>
			</div>
	</div>
	)
}

export default SignIn