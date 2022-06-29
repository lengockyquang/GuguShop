import { Button } from "antd";
import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { checkLoginAsync, logoutEvent } from "../redux/identitySlice";
import { identitySelector } from "../redux/selector";
import { logout } from "../services/identity.service";
import { displayErrorNotify } from "../utils/common";
import { useNavigate } from 'react-router-dom';

type Props = {
	children: React.ReactChild
	| React.ReactChild[]
	| React.ReactNode
	| JSX.Element
	| JSX.Element[]
	;
};

const ProtectedRoute = (props: Props) => {
	const navigate = useNavigate();
	const identityInfo = useSelector(identitySelector);
	const dispatch = useDispatch();


	useEffect(() => {
		dispatch(checkLoginAsync());
	},[dispatch]);

	const onLogout = async () =>{
		const response = await logout();
		if(response.status === 200){
			dispatch(logoutEvent);
			navigate('/login');
		}
		else{
			displayErrorNotify("Đăng xuất thất bại !");
		}
	}
	
	if(!identityInfo.isAuthenticated){
		navigate('/login');
	}

	return (
		<div className="auth-layout">
			Xin chào {identityInfo.userName}
			<Button type="primary" onClick={onLogout} style={{
				float:'right'
			}}>
				Đăng xuất
			</Button>
			<hr/>
			{props.children}
		</div>
	);
};

export default ProtectedRoute;