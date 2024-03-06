import React, { useState } from 'react';
import { Form, Button } from 'react-bootstrap';
import { toast } from 'react-toastify';

function AddProductForm({ onAdd }) {
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
        <Form onSubmit={handleSubmit}>
            <div>
                <h4>Thêm mới sản phẩm</h4>
                <div style={{ display: 'flex', alignItems: 'center' }}>
                    <i class="fa-light fa-file fa-5x" style={{ marginRight: '10px' }} />
                    <Button style={{ marginTop: '-30px' }} variant="info" type="submit">
                        Thêm ảnh
                    </Button>
                    <Button style={{ marginLeft: '20px', marginTop: '-30px' }} variant="light" type="submit" onClick={handleCancel}>
                        Xóa
                    </Button>
                </div>
                <div style={{ marginTop: '-20px', marginLeft: '80px' }}>
                    <p>JPG,GIF hoặc PNG. kÍCH Thước tối da 5000px</p>
                </div>
            </div>
            <div className="row">
                <div className="col-sm-6">
                    <Form.Group controlId="name">
                        <Form.Label>Tên sản phẩm*</Form.Label>
                        <Form.Control type="text" name="name" value={product.name} onChange={handleChange} />
                    </Form.Group>
                    <Form.Group controlId="supplier">
                        <Form.Label>Nhà cung cấp*</Form.Label>
                        <Form.Control type="text" name="supplier" value={product.supplier} onChange={handleChange} />
                    </Form.Group>
                    <Form.Group controlId="code">
                        <Form.Label>Mã Sản Phẩm</Form.Label>
                        <Form.Control type="text" name="code" value={product.code} onChange={handleChange} />
                    </Form.Group>
                    <Form.Group controlId="unit">
                        <Form.Label>Đơn vị</Form.Label>
                        <Form.Control type="text" name="unit" value={product.unit} onChange={handleChange} />
                    </Form.Group>
                </div>
                <div className="col-sm-6">
                    <Form.Group controlId="category">
                        <Form.Label>Loại sản phẩm*</Form.Label>
                        <Form.Control as="select" className="form-select" aria-label="Default select example">
                            <option defaultValue>Open this select menu</option>
                            <option value="1">One</option>
                            <option value="2">Two</option>
                            <option value="3">Three</option>
                        </Form.Control>
                    </Form.Group>
                    <Form.Group controlId="stock">
                        <Form.Label>Barcode</Form.Label>
                        <Form.Control type="text" name="stock" value={product.stock} onChange={handleChange} />
                    </Form.Group>


                </div>
            </div>
            <Button style={{ marginTop: '20px' }} variant="info" type="submit">
                Thêm sản phẩm
            </Button>

            <Button style={{ marginLeft: '20px', marginTop: '20px' }} variant="light" type="submit" onClick={handleCancel}>
                Hủy
            </Button>
        </Form>
    );
}

export default AddProductForm;
