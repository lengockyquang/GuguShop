import _ from "lodash";
import { useEffect, useState } from "react";
import { ProductHomepageDto } from "../dtos/product.homepage";
import ProductItem from "../features/customer/product/components/product-item"
import { okStatusCode } from "../services/identity.service";
import { loadHomepageProducts } from "../services/product.service";
import Loading from "./Loading";

function HomePage() {
    const [loading, setLoading] = useState<boolean>(true);
    const [products, setProducts] = useState<Array<ProductHomepageDto[]>>([]);

    useEffect(() => {
        const loadData = async () => {
            const response = await loadHomepageProducts();
            if (response.status === okStatusCode) {
                const allData = response.data;
                const dataByPages = [];
                for (let index = 0; index < allData.length; index += 4) {
                    dataByPages.push(allData.slice(index, index + 4));
                }
                setProducts(dataByPages);
            }
            setTimeout(() => {
                setLoading(false)
            }, 500);
        }
        loadData();
    }, [])

    if (loading) {
        return <Loading loading={loading} />
    }

    const renderProducts = (products: Array<ProductHomepageDto[]>) => {
        return _.map(products, (productsByRow: ProductHomepageDto[]) => {
            return (
                <div className="row gx-4 gx-lg-5 row-cols-sm-3 row-cols-md-3 row-cols-xl-4">
                    {renderProductItem(productsByRow)}
                </div>
            )
        });
    }

    const renderProductItem = (productsByRow: ProductHomepageDto[]) => {
        return productsByRow.map((product: ProductHomepageDto, index: number) => {
            return <ProductItem
                key={`product-${index}`}
                name={product.name}
                isSale={product.isSale}
                price={product.price}
                thumbnail={product.thumbnail}
            />
        }) 
    }

    return (
        <section className='py-5'>
            <div className="container px-4 px-lg-5 mt-5">
                {renderProducts(products)}
            </div>
        </section>
    )
}

export default HomePage