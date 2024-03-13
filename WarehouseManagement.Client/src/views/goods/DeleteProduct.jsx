import React, { useState } from 'react';
import { Form, Button } from 'react-bootstrap';

function DeleteProductForm({ onAdd }) {
    const [product, setProduct] = useState({
        code: '',
        name: '',
        supplier: '',
        category: '',
        stock: '',
        unit: '',
        createDate: '',
        status: '',
    });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setProduct(prevProduct => ({
            ...prevProduct,
            [name]: value
        }));
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        onAdd(product);
    };

    const handleCancel = () => {
        // Quay lại trang trước đó
        window.history.back();
    };

    return (
        <Form>
            <div className="edit-product-form">
                <h4>Xóa sản phẩm</h4>
                <div className="image-section">
                    <img style={{ width: "150px" }} src='https://cdn.hoanghamobile.com/i/preview/Uploads/2023/09/13/iphone-15-pro-max-natural-titanium-pure-back-iphone-15-pro-max-natural-titanium-pure-front-2up-screen-usen.png'></img>



                </div>


                <div className="row">
                    <div className="col-sm-6">
                        <Form.Group controlId="name">
                            <Form.Label>Tên sản phẩm*</Form.Label>
                            <Form.Control type="text" className='inputCSS' name="name" placeholder="iPhone 15 Pro Max" readOnly />
                        </Form.Group>
                        <Form.Group controlId="supplier">
                            <Form.Label>Nhà cung cấp*</Form.Label>
                            <Form.Control type="text" className='inputCSS' name="supplier" placeholder="Apple" readOnly />
                        </Form.Group>
                        <Form.Group controlId="code">
                            <Form.Label>Mã Sản Phẩm</Form.Label>
                            <Form.Control type="text" className='inputCSS' name="code" placeholder="ip15prm" readOnly />
                        </Form.Group>
                        <Form.Group controlId="unit">
                            <Form.Label>Đơn vị</Form.Label>
                            <Form.Control type="text" className='inputCSS' name="unit" placeholder="Chiếc" readOnly />
                        </Form.Group>
                    </div>
                    <div className="col-sm-6">
                        <Form.Group controlId="category">
                            <Form.Label>Loại sản phẩm*</Form.Label>
                            <Form.Control as="select" className="form-select inputCSS" aria-label="Default select example" disabled value="1">
                                <option defaultValue>Open this select menu</option>
                                <option value="1" >One</option>
                                <option value="2">Two</option>
                                <option value="3">Three</option>
                            </Form.Control>
                        </Form.Group>
                        <Form.Group controlId="stock" >
                            <Form.Label >Barcode</Form.Label>
                            <Form.Control type="text" className='inputCSS' name="stock" readOnly />
                        </Form.Group>
                    </div>
                </div>
                <Button className="update-button" variant="danger" type="submit">
                    Xóa sản phẩm
                </Button>
                &nbsp;
                <Button className="cancel-button" variant="light" type="submit">
                    Hủy
                </Button>
            </div>
        </Form >
    );
}

export default DeleteProductForm;