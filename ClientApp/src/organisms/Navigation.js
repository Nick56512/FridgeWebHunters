import MyNavLink from "../atoms/MyNavLink"
import "../styles/css/index.css"

function Navigation(){

	return(
		<header>
			<div className="container navigation">
				<div className="navigation__logo">
					<MyNavLink className="header__link" to="/">
						<div className="logo">
							<svg width="25" height="25" viewBox="0 0 25 25" fill="none" xmlns="http://www.w3.org/2000/svg">
							<path d="M12.5 0C9.18479 0 6.00537 1.31696 3.66116 3.66116C1.31696 6.00537 0 9.18479 0 12.5C0 15.8152 1.31696 18.9946 3.66116 21.3388C6.00537 23.683 9.18479 25 12.5 25C15.8152 25 18.9946 23.683 21.3388 21.3388C23.683 18.9946 25 15.8152 25 12.5C25 11.8056 24.9444 11.1111 24.8194 10.4167C24.4444 9.72222 23.6111 9.72222 23.6111 9.72222H20.8333V8.33333C20.8333 6.94444 19.4444 6.94444 19.4444 6.94444H16.6667V5.55556C16.6667 4.16667 15.2778 4.16667 15.2778 4.16667H13.8889V1.38889C13.8889 0 12.5 0 12.5 0ZM9.02778 4.16667C9.58031 4.16667 10.1102 4.38616 10.5009 4.77686C10.8916 5.16756 11.1111 5.69747 11.1111 6.25C11.1111 6.80253 10.8916 7.33244 10.5009 7.72314C10.1102 8.11384 9.58031 8.33333 9.02778 8.33333C8.47524 8.33333 7.94534 8.11384 7.55464 7.72314C7.16394 7.33244 6.94444 6.80253 6.94444 6.25C6.94444 5.69747 7.16394 5.16756 7.55464 4.77686C7.94534 4.38616 8.47524 4.16667 9.02778 4.16667ZM4.86111 9.72222C5.41365 9.72222 5.94355 9.94172 6.33425 10.3324C6.72495 10.7231 6.94444 11.253 6.94444 11.8056C6.94444 12.3581 6.72495 12.888 6.33425 13.2787C5.94355 13.6694 5.41365 13.8889 4.86111 13.8889C4.30858 13.8889 3.77867 13.6694 3.38797 13.2787C2.99727 12.888 2.77778 12.3581 2.77778 11.8056C2.77778 11.253 2.99727 10.7231 3.38797 10.3324C3.77867 9.94172 4.30858 9.72222 4.86111 9.72222ZM11.8056 11.1111C12.3581 11.1111 12.888 11.3306 13.2787 11.7213C13.6694 12.112 13.8889 12.6419 13.8889 13.1944C13.8889 13.747 13.6694 14.2769 13.2787 14.6676C12.888 15.0583 12.3581 15.2778 11.8056 15.2778C11.253 15.2778 10.7231 15.0583 10.3324 14.6676C9.94172 14.2769 9.72222 13.747 9.72222 13.1944C9.72222 12.6419 9.94172 12.112 10.3324 11.7213C10.7231 11.3306 11.253 11.1111 11.8056 11.1111ZM18.75 13.8889C19.3025 13.8889 19.8324 14.1084 20.2231 14.4991C20.6138 14.8898 20.8333 15.4197 20.8333 15.9722C20.8333 16.5248 20.6138 17.0547 20.2231 17.4454C19.8324 17.8361 19.3025 18.0556 18.75 18.0556C18.1975 18.0556 17.6676 17.8361 17.2769 17.4454C16.8862 17.0547 16.6667 16.5248 16.6667 15.9722C16.6667 15.4197 16.8862 14.8898 17.2769 14.4991C17.6676 14.1084 18.1975 13.8889 18.75 13.8889ZM11.1111 18.0556C11.6636 18.0556 12.1935 18.275 12.5843 18.6658C12.975 19.0565 13.1944 19.5864 13.1944 20.1389C13.1944 20.6914 12.975 21.2213 12.5843 21.612C12.1935 22.0027 11.6636 22.2222 11.1111 22.2222C10.5586 22.2222 10.0287 22.0027 9.63797 21.612C9.24727 21.2213 9.02778 20.6914 9.02778 20.1389C9.02778 19.5864 9.24727 19.0565 9.63797 18.6658C10.0287 18.275 10.5586 18.0556 11.1111 18.0556Z" fill="#5C4F38"/>
							</svg>
							<span className="logo__text">HungryLand</span>
						</div>
					</MyNavLink>
				</div>
				<div className="navigation__main">
					<MyNavLink className="header__link" to="/">Головна</MyNavLink>
					<MyNavLink className="header__link" to="/recipes">Рецепти</MyNavLink>
					<MyNavLink className="header__link" to="/ingredients">Холодильник</MyNavLink>
				</div>
				<div className="navigation__user">
					<MyNavLink className="header__link" to="/signIn">Увійти</MyNavLink>
				</div>
			 </div>
		</header>
	)
}

export default Navigation