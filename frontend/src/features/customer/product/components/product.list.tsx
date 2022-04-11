import React from 'react'


class ProductList extends React.Component {


    render() {
        return (
            <div id="app">

                <header className="header_area">
                    <div className="classy-nav-container breakpoint-off d-flex align-items-center justify-content-between">

                        <nav className="classy-navbar" id="essenceNav">

                            <a className="nav-brand" href="https://google.com">Jassa</a>

                            <div className="classy-navbar-toggler">
                                <span className="navbarToggler"><span></span><span></span><span></span></span>
                            </div>

                            <div className="classy-menu">

                                <div className="classycloseIcon">
                                    <div className="cross-wrap"><span className="top"></span><span className="bottom"></span></div>
                                </div>

                                <div className="classynav">
                                    <ul>
                                        <li><a href="https://google.com">Shop</a>
                                            <div className="megamenu">
                                                <ul className="single-mega cn-col-4">
                                                    <li className="title">Women's Collection</li>
                                                    <li><a href="https://google.com">Dresses</a></li>
                                                    <li><a href="https://google.com">Blouses &amp; Shirts</a></li>
                                                    <li><a href="https://google.com">T-shirts</a></li>
                                                    <li><a href="https://google.com">Rompers</a></li>
                                                    <li><a href="https://google.com">Bras &amp; Panties</a></li>
                                                </ul>
                                                <ul className="single-mega cn-col-4">
                                                    <li className="title">Men's Collection</li>
                                                    <li><a href="https://google.com">T-Shirts</a></li>
                                                    <li><a href="https://google.com">Polo</a></li>
                                                    <li><a href="https://google.com">Shirts</a></li>
                                                    <li><a href="https://google.com">Jackets</a></li>
                                                    <li><a href="https://google.com">Trench</a></li>
                                                </ul>
                                                <ul className="single-mega cn-col-4">
                                                    <li className="title">Kid's Collection</li>
                                                    <li><a href="https://google.com">Dresses</a></li>
                                                    <li><a href="https://google.com">Shirts</a></li>
                                                    <li><a href="https://google.com">T-shirts</a></li>
                                                    <li><a href="https://google.com">Jackets</a></li>
                                                    <li><a href="https://google.com">Trench</a></li>
                                                </ul>
                                                <div className="single-mega cn-col-4">
                                                    <img src="assets/img/bg-img/bg-6.jpg" alt="" />
                                                </div>
                                            </div>
                                        </li>
                                        <li><a href="https://google.com">Pages</a>
                                            <ul className="dropdown">
                                                <li><a href="https://google.com">Home</a></li>
                                                <li><a href="https://google.com">Shop</a></li>
                                                <li><a href="https://google.com">Product Details</a></li>
                                                <li><a href="https://google.com">Checkout</a></li>
                                                <li><a href="https://google.com">Blog</a></li>
                                                <li><a href="https://google.com">Single Blog</a></li>
                                                <li><a href="https://google.com">Regular Page</a></li>
                                                <li><a href="https://google.com">Contact</a></li>
                                            </ul>
                                        </li>
                                        <li><a href="https://google.com">Blog</a></li>
                                        <li><a href="https://google.com">Contact</a></li>
                                    </ul>
                                </div>

                            </div>
                        </nav>

                        <div className="header-meta d-flex clearfix justify-content-end">

                            <div className="search-area">
                                <form action="#" method="post">
                                    <input type="search" name="search" id="headerSearch" placeholder="Type for search" />
                                    <button type="submit"><i className="fa fa-search" aria-hidden="true"></i></button>
                                </form>
                            </div>

                            <div className="favourite-area">
                                <a href="https://google.com"><img src="assets/img/core-img/heart.svg" alt="" /></a>
                            </div>

                            <div className="user-login-info">
                                <a href="https://google.com"><img src="assets/img/core-img/user.svg" alt="" /></a>
                            </div>

                            <div className="cart-area">
                                <a href="https://google.com" id="essenceCartBtn"><img src="assets/img/core-img/bag.svg" alt="" /> <span>3</span></a>
                            </div>
                        </div>
                    </div>
                </header>
                <div className="cart-bg-overlay"></div>
                <div className="right-side-cart-area">

                    <div className="cart-button">
                        <a href="https://google.com" id="rightSideCart"><img src="assets/img/core-img/bag.svg" alt="" /> <span>3</span></a>
                    </div>
                    <div className="cart-content d-flex">

                        <div className="cart-list">

                            <div className="single-cart-item">
                                <a href="https://google.com" className="product-image">
                                    <img src="assets/img/product-img/product-1.jpg" className="cart-thumb" alt="" />

                                    <div className="cart-item-desc">
                                        <span className="product-remove"><i className="fa fa-close" aria-hidden="true"></i></span>
                                        <span className="badge">Mango</span>
                                        <h6>Button Through Strap Mini Dress</h6>
                                        <p className="size">Size: S</p>
                                        <p className="color">Color: Red</p>
                                        <p className="price">$45.00</p>
                                    </div>
                                </a>
                            </div>

                            <div className="single-cart-item">
                                <a href="https://google.com" className="product-image">
                                    <img src="assets/img/product-img/product-2.jpg" className="cart-thumb" alt="" />

                                    <div className="cart-item-desc">
                                        <span className="product-remove"><i className="fa fa-close" aria-hidden="true"></i></span>
                                        <span className="badge">Mango</span>
                                        <h6>Button Through Strap Mini Dress</h6>
                                        <p className="size">Size: S</p>
                                        <p className="color">Color: Red</p>
                                        <p className="price">$45.00</p>
                                    </div>
                                </a>
                            </div>

                            <div className="single-cart-item">
                                <a href="https://google.com" className="product-image">
                                    <img src="assets/img/product-img/product-3.jpg" className="cart-thumb" alt="" />

                                    <div className="cart-item-desc">
                                        <span className="product-remove"><i className="fa fa-close" aria-hidden="true"></i></span>
                                        <span className="badge">Mango</span>
                                        <h6>Button Through Strap Mini Dress</h6>
                                        <p className="size">Size: S</p>
                                        <p className="color">Color: Red</p>
                                        <p className="price">$45.00</p>
                                    </div>
                                </a>
                            </div>
                        </div>

                        <div className="cart-amount-summary">
                            <h2>Summary</h2>
                            <ul className="summary-table">
                                <li><span>subtotal:</span> <span>$274.00</span></li>
                                <li><span>delivery:</span> <span>Free</span></li>
                                <li><span>discount:</span> <span>-15%</span></li>
                                <li><span>total:</span> <span>$232.00</span></li>
                            </ul>
                            <div className="checkout-btn mt-100">
                                <a href="https://google.com" className="btn essence-btn">check out</a>
                            </div>
                        </div>
                    </div>
                </div>
                <section className="welcome_area bg-img background-overlay" style={{ backgroundImage: "url(assets/img/bg-img/bg-1.jpg)" }}>
                    <div className="container h-100">
                        <div className="row h-100 align-items-center">
                            <div className="col-12">
                                <div className="hero-content">
                                    <h6>asoss</h6>
                                    <h2>New Collection</h2>
                                    <a href="https://google.com" className="btn essence-btn">view collection</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
                <div className="top_catagory_area section-padding-80 clearfix">
                    <div className="container">
                        <div className="row justify-content-center">

                            <div className="col-12 col-sm-6 col-md-4">
                                <div className="single_catagory_area d-flex align-items-center justify-content-center bg-img" style={{ backgroundImage: "url(assets/img/bg-img/bg-2.jpg)" }}>
                                    <div className="catagory-content">
                                        <a href="https://google.com">Clothing</a>
                                    </div>
                                </div>
                            </div>

                            <div className="col-12 col-sm-6 col-md-4">
                                <div className="single_catagory_area d-flex align-items-center justify-content-center bg-img" style={{ backgroundImage: "url(assets/img/bg-img/bg-3.jpg)" }}>
                                    <div className="catagory-content">
                                        <a href="https://google.com">Shoes</a>
                                    </div>
                                </div>
                            </div>

                            <div className="col-12 col-sm-6 col-md-4">
                                <div className="single_catagory_area d-flex align-items-center justify-content-center bg-img" style={{ backgroundImage: "url(assets/img/bg-img/bg-4.jpg)" }}>
                                    <div className="catagory-content">
                                        <a href="https://google.com">Accessories</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div className="cta-area">
                    <div className="container">
                        <div className="row">
                            <div className="col-12">
                                <div className="cta-content bg-img background-overlay" style={{ backgroundImage: "url(assets/img/bg-img/bg-5.jpg)" }}>
                                    <div className="h-100 d-flex align-items-center justify-content-end">
                                        <div className="cta--text">
                                            <h6>-60%</h6>
                                            <h2>Global Sale</h2>
                                            <a href="https://google.com" className="btn essence-btn">Buy Now</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <section className="new_arrivals_area section-padding-80 clearfix">
                    <div className="container">
                        <div className="row">
                            <div className="col-12">
                                <div className="section-heading text-center">
                                    <h2>Popular Products</h2>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div className="container">
                        <div className="row">
                            <div className="col-12">
                                <div className="popular-products-slides owl-carousel">

                                    <div className="single-product-wrapper">

                                        <div className="product-img">
                                            <img src="assets/img/product-img/product-1.jpg" alt="" />

                                            <img className="hover-img" src="assets/img/product-img/product-2.jpg" alt="" />

                                            <div className="product-favourite">
                                                <a href="https://google.com" className="favme fa fa-heart"></a>
                                            </div>
                                        </div>

                                        <div className="product-description">
                                            <span>topshop</span>
                                            <a href="https://google.com">
                                                <h6>Knot Front Mini Dress</h6>
                                            </a>
                                            <p className="product-price">$80.00</p>

                                            <div className="hover-content">

                                                <div className="add-to-cart-btn">
                                                    <a href="https://google.com" className="btn essence-btn">Add to Cart</a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div className="single-product-wrapper">

                                        <div className="product-img">
                                            <img src="assets/img/product-img/product-2.jpg" alt="" />

                                            <img className="hover-img" src="assets/img/product-img/product-3.jpg" alt="" />

                                            <div className="product-favourite">
                                                <a href="https://google.com" className="favme fa fa-heart"></a>
                                            </div>
                                        </div>

                                        <div className="product-description">
                                            <span>topshop</span>
                                            <a href="https://google.com">
                                                <h6>Poplin Displaced Wrap Dress</h6>
                                            </a>
                                            <p className="product-price">$80.00</p>

                                            <div className="hover-content">

                                                <div className="add-to-cart-btn">
                                                    <a href="https://google.com" className="btn essence-btn">Add to Cart</a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div className="single-product-wrapper">

                                        <div className="product-img">
                                            <img src="assets/img/product-img/product-3.jpg" alt="" />

                                            <img className="hover-img" src="assets/img/product-img/product-4.jpg" alt="" />

                                            <div className="product-badge offer-badge">
                                                <span>-30%</span>
                                            </div>

                                            <div className="product-favourite">
                                                <a href="https://google.com" className="favme fa fa-heart"></a>
                                            </div>
                                        </div>

                                        <div className="product-description">
                                            <span>mango</span>
                                            <a href="https://google.com">
                                                <h6>PETITE Crepe Wrap Mini Dress</h6>
                                            </a>
                                            <p className="product-price"><span className="old-price">$75.00</span> $55.00</p>

                                            <div className="hover-content">

                                                <div className="add-to-cart-btn">
                                                    <a href="https://google.com" className="btn essence-btn">Add to Cart</a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div className="single-product-wrapper">

                                        <div className="product-img">
                                            <img src="assets/img/product-img/product-4.jpg" alt="" />

                                            <img className="hover-img" src="assets/img/product-img/product-5.jpg" alt="" />

                                            <div className="product-badge new-badge">
                                                <span>New</span>
                                            </div>

                                            <div className="product-favourite">
                                                <a href="https://google.com" className="favme fa fa-heart"></a>
                                            </div>
                                        </div>

                                        <div className="product-description">
                                            <span>mango</span>
                                            <a href="https://google.com">
                                                <h6>PETITE Belted Jumper Dress</h6>
                                            </a>
                                            <p className="product-price">$80.00</p>

                                            <div className="hover-content">

                                                <div className="add-to-cart-btn">
                                                    <a href="https://google.com" className="btn essence-btn">Add to Cart</a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
                <div className="brands-area d-flex align-items-center justify-content-between">

                    <div className="single-brands-logo">
                        <img src="assets/img/core-img/brand1.png" alt="" />
                    </div>

                    <div className="single-brands-logo">
                        <img src="assets/img/core-img/brand2.png" alt="" />
                    </div>

                    <div className="single-brands-logo">
                        <img src="assets/img/core-img/brand3.png" alt="" />
                    </div>

                    <div className="single-brands-logo">
                        <img src="assets/img/core-img/brand4.png" alt="" />
                    </div>

                    <div className="single-brands-logo">
                        <img src="assets/img/core-img/brand5.png" alt="" />
                    </div>

                    <div className="single-brands-logo">
                        <img src="assets/img/core-img/brand6.png" alt="" />
                    </div>
                </div>
                <footer className="footer_area clearfix">
                    <div className="container">
                        <div className="row">

                            <div className="col-12 col-md-6">
                                <div className="single_widget_area d-flex mb-30">

                                    <div className="footer-logo mr-50">
                                        <a href="https://google.com">Jassa</a>
                                    </div>

                                    <div className="footer_menu">
                                        <ul>
                                            <li><a href="https://google.com">Shop</a></li>
                                            <li><a href="https://google.com">Blog</a></li>
                                            <li><a href="https://google.com">Contact</a></li>
                                        </ul>
                                    </div>
                                </div>
                            </div>

                            <div className="col-12 col-md-6">
                                <div className="single_widget_area mb-30">
                                    <ul className="footer_widget_menu">
                                        <li><a href="https://google.com">Order Status</a></li>
                                        <li><a href="https://google.com">Payment Options</a></li>
                                        <li><a href="https://google.com">Shipping and Delivery</a></li>
                                        <li><a href="https://google.com">Guides</a></li>
                                        <li><a href="https://google.com">Privacy Policy</a></li>
                                        <li><a href="https://google.com">Terms of Use</a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <div className="row align-items-end">

                            <div className="col-12 col-md-6">
                                <div className="single_widget_area">
                                    <div className="footer_heading mb-30">
                                        <h6>Subscribe</h6>
                                    </div>
                                    <div className="subscribtion_form">
                                        <form>
                                            <input type="email" name="mail" className="mail" placeholder="Your email here" />
                                            <button type="button" className="submit"><i className="fa fa-long-arrow-right" aria-hidden="true"></i></button>
                                        </form>
                                    </div>
                                </div>
                            </div>

                            <div className="col-12 col-md-6">
                                <div className="single_widget_area">
                                    <div className="footer_social_area">
                                        <a href="https://google.com" data-toggle="tooltip" data-placement="top" title="Facebook"><i className="fa fa-facebook" aria-hidden="true"></i></a>
                                        <a href="https://google.com" data-toggle="tooltip" data-placement="top" title="Instagram"><i className="fa fa-instagram" aria-hidden="true"></i></a>
                                        <a href="https://google.com" data-toggle="tooltip" data-placement="top" title="Twitter"><i className="fa fa-twitter" aria-hidden="true"></i></a>
                                        <a href="https://google.com" data-toggle="tooltip" data-placement="top" title="Pinterest"><i className="fa fa-pinterest" aria-hidden="true"></i></a>
                                        <a href="https://google.com" data-toggle="tooltip" data-placement="top" title="Youtube"><i className="fa fa-youtube-play" aria-hidden="true"></i></a>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div className="row mt-5">
                            <div className="col-md-12 text-center">
                                <p>

                                    Copyright &copy;2021 All rights reserved | Made with <i className="fa fa-heart-o" aria-hidden="true"></i> by <a href="https://therichpost.com" target="_blank">therichpost</a>, distributed by <a href="https://therichpost.com/" target="_blank">therichpost</a>
                                </p>
                            </div>
                        </div>
                    </div>
                </footer>
            </div>

        );
    }
}
export default ProductList;
