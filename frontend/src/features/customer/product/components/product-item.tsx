import React from 'react'

interface Props {
  isSale: boolean;
  name: string;
  price: string;
  thumbnail?: string;
}

function ProductItem(props: Props){
  const defaultThumbnail = "https://dummyimage.com/450x300/dee2e6/6c757d.jpg";
  return (
    <div className="col mb-5">
      <div className="card h-100">
        {
          props.isSale && (
            <div className="badge bg-dark text-white position-absolute" style={{top: "0.5rem", right: "0.5rem"}}>Sale</div>
          )
        }
        <img className="card-img-top" src={props.thumbnail ?? defaultThumbnail} alt="..." />
        <div className="card-body p-4">
          <div className="text-center">
            <h5 className="fw-bolder">{props.name}</h5>
            {/* <span className="text-muted text-decoration-line-through">$50.00</span> */}
            {props.price ?? "$0.00"}
          </div>
        </div>
        <div className="card-footer p-4 pt-0 border-top-0 bg-transparent">
          <div className="text-center">
            <a className="btn btn-outline-dark mt-auto" href="https://dummyimage.com/450x300/dee2e6/6c757d.jpg">
              Add to cart
            </a>
          </div>
        </div>
      </div>
    </div>
  )
}

export default ProductItem;


