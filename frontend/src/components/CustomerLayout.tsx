import React, { CSSProperties, ReactNode } from 'react';
import Footer from './Footer';
import Header from './Header';


type Props = {
    children: ReactNode;
    style?: CSSProperties;
    appClassName?: string;
};

const CustomerLayout = (props: Props) => {
    return (
        <div>
            Customer Layout
            <Header />
            {props.children}
            <Footer />
        </div>
    )
}

export default CustomerLayout
