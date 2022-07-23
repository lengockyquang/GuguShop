import { Button } from 'antd';
import { useNavigate } from 'react-router-dom';
const PrivatePage = () => {
    const navigate = useNavigate();
    
    const goToHome = () => {
        navigate("/");
    }

    return (
        <div className='private'>
            <h2>Private</h2>
            <br />
            <Button onClick={goToHome} >Go to home</Button>
        </div>
    )
}

export default PrivatePage