import React, { Component } from "react";
import Validation from "../validation";
import {Link, Route} from "react-router-dom";
import UpdateProduct from "./updateproduct";

class ProductList extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      error: null,
      isLoaded: false,
      items: []
    };
  }

  componentDidMount() {
    setTimeout(() => {
      fetch("http://localhost:5000/api/products")
          .then(res => res.json())
          .then(
              result => {
                this.setState({
                  isLoaded: true,
                  items: result
                });
              },
              // Note: it's important to handle errors here
              // instead of a catch() block so that we don't swallow
              // exceptions from actual bugs in components.
              error => {
                this.setState({
                  isLoaded: true,
                  error
                });
              }
          );
    }, 200);

  }

  render() {
    const { error, isLoaded, items } = this.state;
    if (error) {
      return <p>Error: {error.message}</p>;
    } else if (!isLoaded) {
      return <p>Loading...</p>;
    } else {
      return (
          <div className="products">
            {items.map(item => (
              <div className="product" key={item.id}>
                <div>
                  <h5>
                    {item.name}
                  </h5>
                  <span className="productDescription">
                    {item.category}
                  </span>
                </div>

                <Link to={{
                  pathname: '/updateproduct',
                  state: item,
                }}>Edit</Link>

              </div>
            ))}
          </div>
      );
    }
  }
}

class Products extends Component {
  render() {
    return (
      <React.Fragment>
        <h1 className="display-4">Products</h1>
        <ProductList />
        <Validation />
      </React.Fragment>
    );
  }
}
export default Products;
