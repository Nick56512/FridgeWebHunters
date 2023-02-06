function registerValidation(email, password, repeatPassword, firstName, lastName){
	let errors = []
	if(email.length < 5){
		errors.push('Некоректна пошта!')
	}
	if(password.length < 9){
		errors.push('Пароль повинен містити більше 9 символів!')
	}

	let upper = 0;
	let lower = 0;
	for(let i = 0; i < password.length; i++){
		let symbol = password[i]
		let isUpperCase = symbol.toUpperCase()==symbol;
		let isLowerCase = symbol.toLowerCase()==symbol;
		if(!!isUpperCase) {upper += 1}
		if(!!isLowerCase) {lower += 1}
	}
	if(upper > 0 && lower > 0){
		upper = 0
	}
	else{
		errors.push('Пароль повинен містити одну велику та одну маленьку літеру!')
	}

	if(firstName.length < 3){
		errors.push("Ім'я складається з трьох або більше символів!")
	}
	if(lastName.length < 3){
		errors.push("Фамілія складається з трьох або більше символів!")
	}
	if(password !== repeatPassword){
		errors.push("Паролі не співпадають!")
	}
	if(true){
		return errors
	}
}

export default registerValidation