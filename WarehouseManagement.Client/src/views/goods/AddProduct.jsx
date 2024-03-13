import React from 'react';
import { Form, Button } from 'react-bootstrap';

function AddProductForm({ }) {
    return (
        <Form>
            <div className="edit-product-form">
                <h4>Thêm sản phẩm</h4>
                <div className="image-section">
                    <i className="fa-regular fa-file-image"></i>
                    <div>
                        <div style={{ display: 'flex', flexDirection: 'column', padding: '5px' }}>
                            <div style={{ padding: '5px' }} >
                                <Button className='ButtonCSS' variant="info" type="submit">
                                    Sửa ảnh
                                </Button>
                                &nbsp;
                                <Button variant="light" type="submit">
                                    Xóa
                                </Button>
                            </div>
                            <em >JPG, GIF hoặc PNG. Kích thước tối đa 5000px</em>
                        </div>
                    </div>


                </div>


                <div className="row">
                    <div className="col-sm-6">
                        <Form.Group controlId="name">
                            <Form.Label>Tên sản phẩm*</Form.Label>
                            <Form.Control type="text" className='inputCSS' name="name" />
                        </Form.Group>
                        <Form.Group controlId="supplier">
                            <Form.Label>Nhà cung cấp*</Form.Label>
                            <Form.Control type="text" className='inputCSS' name="supplier" />
                        </Form.Group>
                        <Form.Group controlId="code">
                            <Form.Label>Mã Sản Phẩm</Form.Label>
                            <Form.Control type="text" className='inputCSS' name="code" />
                        </Form.Group>
                        <Form.Group controlId="unit">
                            <Form.Label>Đơn vị</Form.Label>
                            <Form.Control type="text" className='inputCSS' name="unit" />
                        </Form.Group>
                    </div>
                    <div className="col-sm-6">
                        <Form.Group controlId="category">
                            <Form.Label>Loại sản phẩm*</Form.Label>
                            <Form.Control as="select" className="form-select inputCSS" aria-label="Default select example">
                                <option defaultValue>Open this select menu</option>
                                <option value="1">One</option>
                                <option value="2">Two</option>
                                <option value="3">Three</option>
                            </Form.Control>
                        </Form.Group>
                        <Form.Group controlId="stock">
                            <Form.Label>Barcode</Form.Label>
                            <Form.Control type="text" className='inputCSS' name="stock" />
                        </Form.Group>
                    </div>
                </div>
                <Button className="update-button ButtonCSS" variant="info" type="submit">
                    Thêm sản phẩm
                </Button>
                &nbsp;
                <Button className="cancel-button" variant="light" type="submit">
                    Hủy
                </Button>
            </div>
        </Form>
    );
}

export default AddProductForm;