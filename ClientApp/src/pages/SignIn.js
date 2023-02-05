import MyNavLink from "../atoms/MyNavLink"

import { Link } from "react-router-dom"

function SignIn(){

	return(
		<>
			<h1>SignIn</h1>
			<MyNavLink to={`/SignUp`}>Нет аккаунта? Зарегистрируйся!</MyNavLink>
		</>
	)
}

export default SignIn