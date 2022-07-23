import { Button } from 'antd';
import { useNavigate } from 'react-router-dom';
function HomePage() {
    const navigate = useNavigate();

    const goToPrivate = () =>{
        navigate("/private");
    }



    return (
        <div className='home'>
            <h2>Home</h2>

            <Button onClick={goToPrivate} >Private</Button>
        </div>
    )
}

export default HomePage