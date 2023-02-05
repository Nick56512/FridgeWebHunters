import MyNavLink from "../atoms/MyNavLink"
import "../styles/css/index.css"
import Button from "../atoms/SignButton"

function SignUp(){

	return(
	<div>
		<img className="bg__page" src={require("../assets/signup_bg.jpg")}></img>
		<div className="container relative">
			<div className="modal__signup">
				<h2 className="title__signup">Реєстрація</h2>
				<div className="signup__flex">
					<input className="Input Input__full" placeholder="Електронна пошта"></input>
					<div className="flex Input__full">
						<input className="Input Input__half" placeholder="Ім'я"></input>
						<input className="Input Input__half" placeholder="Прізвище"></input>
					</div>
					<input className="Input Input__full" placeholder="Пароль" type={'password'}></input>
					<input className="Input Input__full" placeholder="Повторіть пароль" type={'password'}></input>
				</div>
				<div className="signup__footer">
					<div className="text">
						<p>У вас вже є аккаунт?</p>
						<MyNavLink  to={`/SignIn`}>Увійдіть!</MyNavLink>
					</div>
					<div>
						<Button>Готово!</Button>
					</div>
				</div>
			</div>
		</div>
	</div>
	)
}

export default SignUp