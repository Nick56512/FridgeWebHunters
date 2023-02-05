
function Button({children, props}) {
	return (
		<div>
			<button className="Button" {...props}>{children}</button>
		</div>
	);
}

export default Button;
