import React, { CSSProperties } from 'react'
import { ReactComponent as IconLoading } from '../assets/loading.svg';

type LoadingProps = {
    text?: string;
    containerStyle?: CSSProperties;
    loading: boolean;
}



const Loading = (props: LoadingProps) => {
    return (
        <div
            className='loading'
            style={{
                display: props.loading ? "flex" : 'none',
                flexDirection: 'column',
                justifyContent: 'center',
                alignItems: 'center',
                width: '100%',
                height: '100%',
                position: 'absolute',
                zIndex: 999999
            }}
        >
            <IconLoading />
            <span>{props.text}</span>
        </div>
    );

};
export default Loading
