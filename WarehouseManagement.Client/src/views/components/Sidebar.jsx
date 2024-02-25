import React from 'react';
import { Container, Row, Col, Nav, NavDropdown, Image } from 'react-bootstrap';

const Sidebar = () => {
    return (

                <Col sm={3} md={3} xl={2} className="px-sm-2 px-0 bg-info bg-gradient">
                    <div className="d-flex flex-column align-items-center align-items-sm-start px-3 pt-2 text-white min-vh-100">
                        <a href="/" className="d-flex align-items-center pb-3 mb-md-0 me-md-auto text-black text-decoration-none">
                            <span className="fs-5 d-none d-sm-inline">WMS</span>
                        </a>
                        <Nav className="nav-pills flex-column mb-sm-auto mb-0 align-items-center align-items-sm-start" id="menu">
                            <Nav.Item className='mb-2'>
                                <Nav.Link className="align-middle px-0 d-flex justify-content-between" style={{ width: 180 }}>
                                    <div className='d-flex'>
                                        <div style={{ width: 30 }}><i className=" fs-4 fa-solid fa-chart-simple"></i></div>
                                        <div><span className="ms-1 d-none d-sm-inline">Thống kê</span></div>
                                    </div>
                                    <div><i className="fa-solid fa-angle-right"></i></div>
                                </Nav.Link>
                            </Nav.Item>
                            <Nav.Item className='mb-2'>
                                <Nav.Link className="align-middle px-0 d-flex justify-content-between" style={{ width: 180 }}>
                                    <div className='d-flex'>
                                        <div style={{ width: 30 }}><i className=" fs-4 fa-regular fa-clipboard"></i></div>
                                        <div><span className="ms-1 d-none d-sm-inline">Quản lý hàng hóa</span></div>
                                    </div>
                                    <div><i className="fa-solid fa-angle-right"></i></div>
                                </Nav.Link>
                            </Nav.Item>
                            <Nav.Item className='mb-2'>
                                <Nav.Link className="align-middle px-0 d-flex justify-content-between" style={{ width: 180 }}>
                                    <div className='d-flex'>
                                        <div style={{ width: 30 }}><i className=" fs-4 fa-solid fa-tent-arrow-down-to-line"></i></div>
                                        <div><span className="ms-1 d-none d-sm-inline">Nhập hàng</span></div>
                                    </div>
                                    <div><i className="fa-solid fa-angle-right"></i></div>
                                </Nav.Link>
                            </Nav.Item>
                            <Nav.Item className='mb-2'>

                                <Nav.Link className="align-middle px-0 d-flex justify-content-between" style={{ width: 180 }}>
                                    <div className='d-flex'>
                                        <div style={{ width: 30 }}><i className=" fs-4 fa-solid fa-right-from-bracket"></i></div>
                                        <div><span className="ms-1 d-none d-sm-inline">Xuất hàng</span></div>
                                    </div>
                                    <div><i className="fa-solid fa-angle-right"></i></div>
                                </Nav.Link>
                            </Nav.Item>
                            <Nav.Item className='mb-2'>

                                <Nav.Link className="align-middle px-0 d-flex justify-content-between" style={{ width: 180 }}>
                                    <div className='d-flex'>
                                        <div style={{ width: 30 }}><i className=" fs-4 fa-solid fa-tent-arrows-down"></i></div>
                                        <div><span className="ms-1 d-none d-sm-inline">Trả hàng</span></div>
                                    </div>
                                    <div><i className="fa-solid fa-angle-right"></i></div>
                                </Nav.Link>
                            </Nav.Item>
                            <Nav.Item className='mb-2'>



                                <Nav.Link className="align-middle px-0 d-flex justify-content-between" style={{ width: 180 }}>
                                    <div className='d-flex'>
                                        <div style={{ width: 30 }}><i className=" fs-4 fa-solid  fa-square-check"></i></div>
                                        <div><span className="ms-1 d-none d-sm-inline">Kiểm hàng</span></div>
                                    </div>
                                    <div><i className="fa-solid fa-angle-right"></i></div>
                                </Nav.Link>
                            </Nav.Item>
                            <Nav.Item className='mb-2'>



                                <Nav.Link className="align-middle px-0 d-flex justify-content-between" style={{ width: 180 }}>
                                    <div className='d-flex'>
                                        <div style={{ width: 30 }}><i className=" fs-4 fa-solid   fa-user-tie"></i></div>
                                        <div><span className="ms-1 d-none d-sm-inline">Nhân viên</span></div>
                                    </div>
                                    <div><i className="fa-solid fa-angle-right"></i></div>
                                </Nav.Link>
                            </Nav.Item>
                            <Nav.Item className='mb-2'>




                                <Nav.Link className="align-middle px-0 d-flex justify-content-between" style={{ width: 180 }}>
                                    <div className='d-flex'>
                                        <div style={{ width: 30 }}><i className=" fs-4 fa-solid fa-phone"></i></div>
                                        <div><span className="ms-1 d-none d-sm-inline">Người hỗ trợ</span></div>
                                    </div>
                                    <div><i className="fa-solid fa-angle-right"></i></div>
                                </Nav.Link>
                            </Nav.Item>
                            <Nav.Item className='mb-2'>
                                <Nav.Link className="align-middle px-0 d-flex justify-content-between" style={{ width: 180 }}>
                                    <div className='d-flex'>
                                        <div style={{ width: 30 }}><i className=" fs-4 fa-solid fa-book"></i></div>
                                        <div><span className="ms-1 d-none d-sm-inline">Tài liệu</span></div>
                                    </div>
                                    <div><i className="fa-solid fa-angle-right"></i></div>
                                </Nav.Link>
                            </Nav.Item>


                        </Nav>
                    </div>
                </Col>
                


    );



}


export default Sidebar;
