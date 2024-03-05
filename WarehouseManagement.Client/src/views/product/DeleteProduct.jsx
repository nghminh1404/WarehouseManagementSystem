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
        <Form onSubmit={handleSubmit}>
            <Form.Group controlId="code">
                <Form.Label>Mã SP</Form.Label>
                <Form.Control type="text" name="code" value={'SP1'} onChange={handleChange} />
            </Form.Group>
            <Form.Group controlId="name">
                <Form.Label>Tên sản phẩm</Form.Label>
                <Form.Control type="text" name="name" value={'OnePlues 7Pro'} onChange={handleChange} />
            </Form.Group>
            <Form.Group controlId="supplier">
                <Form.Label>Nhà cung cấp</Form.Label>
                <Form.Control type="text" name="supplier" value={'OnePlues'} onChange={handleChange} />
            </Form.Group>
            <Form.Group controlId="category">
                <Form.Label>Thể loại</Form.Label>
                <Form.Control type="text" name="category" value={'SmartPhone'} onChange={handleChange} />
            </Form.Group>
            <Form.Group controlId="stock">
                <Form.Label>Tồn kho</Form.Label>
                <Form.Control type="text" name="stock" value={'102'} onChange={handleChange} />
            </Form.Group>
            <Form.Group controlId="unit">
                <Form.Label>Đơn vị</Form.Label>
                <Form.Control type="text" name="unit" value={'Chiec'} onChange={handleChange} />
            </Form.Group>
            <Form.Group controlId="createDate">
                <Form.Label>Ngày khởi tạo</Form.Label>
                <Form.Control type="text" name="createDate" value={'17/02/2003'} onChange={handleChange} />
            </Form.Group>
            <Form.Group controlId="status">
                <Form.Label>Trạng thái</Form.Label>
                <Form.Control type="text" name="status" value={'Đang giao dịch'} onChange={handleChange} />
            </Form.Group>
            <Button style={{ marginTop: '20px' }} variant="primary" type="submit">
                Xóa sản phẩm
            </Button>

            <Button style={{ marginLeft: '20px', marginTop: '20px' }} variant="primary" type="submit" onClick={handleCancel}>
                Hủy
            </Button>
        </Form>
    );
}

export default DeleteProductForm;