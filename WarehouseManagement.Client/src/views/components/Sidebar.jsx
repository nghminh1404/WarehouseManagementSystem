import React from 'react';
import { Container, Row, Col, Nav, Navbar, NavDropdown, Image } from 'react-bootstrap';

import logo from '../../assets/images/logo.png';

const Sidebar = () => {
    return (
        <Col sm={3} md={3} xl={2} className="px-sm-2  px-0  " style={{ width: '270px' }}>
            <div className="d-flex flex-column   align-items-center px-3 pt-2 text-white min-vh-100">
                <a
                    href="/"
                    className="d-flex align-items-center pb-3 mb-md-0 me-md-auto text-sidebar text-decoration-none"
                >
                    <Navbar.Brand href="#" className="p-1">
                        <img src={logo} className="px-2 ms-2" height="40" alt="MDB Logo" loading="lazy" />
                    </Navbar.Brand>

                    <span className="fs-5 d-none d-sm-inline fw-bold ">WMS</span>
                </a>
                <Nav
                    className="nav-pills flex-column  mb-sm-auto mb-0 align-items-center align-items-sm-start"
                    id="menu"
                >
                    <Nav.Item className="mb-2 ">
                        <Nav.Link
                            className="align-middle sidebar-item text-sidebar px-0 d-flex justify-content-between"
                            style={{ width: 180 }}
                        >
                            <div className="d-flex">
                                <div style={{ width: 30 }}>
                                    <i class="fa-duotone fa-chart-simple fa-xl "></i>
                                </div>
                                <div>
                                    <span className=" d-none d-sm-inline ">Thống kê</span>
                                </div>
                            </div>
                            <div>
                                <i className=" fa-solid fa-angle-right"></i>
                            </div>
                        </Nav.Link>
                    </Nav.Item>
                    <Nav.Item className="mb-2">
                        <Nav.Link
                            className="align-middle sidebar-item text-sidebar px-0 d-flex justify-content-between"
                            style={{ width: 180 }}
                        >
                            <div className="d-flex">
                                <div style={{ width: 30 }}>
                                    <i class="fa-duotone fa-clipboard fa-xl"></i>
                                </div>
                                <div>
                                    <span className="ms-1 d-none d-sm-inline">Quản lý hàng hóa</span>
                                </div>
                            </div>
                            <div>
                                <i className="fa-solid fa-angle-right"></i>
                            </div>
                        </Nav.Link>
                    </Nav.Item>
                    <Nav.Item className="mb-2">
                        <Nav.Link
                            className="align-middle sidebar-item text-sidebar px-0 d-flex justify-content-between"
                            style={{ width: 180 }}
                        >
                            <div className="d-flex">
                                <div style={{ width: 30 }}>
                                    <i class="fa-duotone fa-file-import fa-xl"></i>
                                </div>
                                <div>
                                    <span className="ms-1 d-none d-sm-inline">Nhập hàng</span>
                                </div>
                            </div>
                            <div>
                                <i className="fa-solid fa-angle-right"></i>
                            </div>
                        </Nav.Link>
                    </Nav.Item>
                    <Nav.Item className="mb-2">
                        <Nav.Link
                            className="align-middle sidebar-item text-sidebar px-0 d-flex justify-content-between"
                            style={{ width: 180 }}
                        >
                            <div className="d-flex">
                                <div style={{ width: 30 }}>
                                    <i class="fa-duotone fa-file-export fa-xl"></i>
                                </div>
                                <div>
                                    <span className="ms-1 d-none d-sm-inline">Xuất hàng</span>
                                </div>
                            </div>
                            <div>
                                <i className="fa-solid fa-angle-right"></i>
                            </div>
                        </Nav.Link>
                    </Nav.Item>
                    <Nav.Item className="mb-2">
                        <Nav.Link
                            className="align-middle sidebar-item text-sidebar px-0 d-flex justify-content-between"
                            style={{ width: 180 }}
                        >
                            <div className="d-flex">
                                <div style={{ width: 30 }}>
                                    <i class="fa-xl fa-duotone fa-rotate-reverse"></i>
                                </div>
                                <div>
                                    <span className="ms-1 d-none d-sm-inline">Trả hàng</span>
                                </div>
                            </div>
                            <div>
                                <i className="fa-solid fa-angle-right"></i>
                            </div>
                        </Nav.Link>
                    </Nav.Item>
                    <Nav.Item className="mb-2">
                        <Nav.Link
                            className="align-middle sidebar-item text-sidebar px-0 d-flex justify-content-between"
                            style={{ width: 180 }}
                        >
                            <div className="d-flex">
                                <div style={{ width: 30 }}>
                                    <i class="fa-xl fa-duotone fa-badge-check fa-swap-opacity"></i>
                                </div>
                                <div>
                                    <span className="ms-1 d-none d-sm-inline">Kiểm hàng</span>
                                </div>
                            </div>
                            <div>
                                <i className="fa-solid fa-angle-right"></i>
                            </div>
                        </Nav.Link>
                    </Nav.Item>
                    <Nav.Item className="mb-2">
                        <Nav.Link
                            className="align-middle sidebar-item text-sidebar px-0 d-flex justify-content-between"
                            style={{ width: 180 }}
                        >
                            <div className="d-flex">
                                <div style={{ width: 30 }}>
                                    <i class="fa-xl fa-duotone fa-user-tie"></i>
                                </div>
                                <div>
                                    <span className="ms-1 d-none d-sm-inline">Nhân viên</span>
                                </div>
                            </div>
                            <div>
                                <i className="fa-solid fa-angle-right"></i>
                            </div>
                        </Nav.Link>
                    </Nav.Item>
                    <Nav.Item className="mb-2">
                        <Nav.Link
                            className="align-middle sidebar-item text-sidebar px-0 d-flex justify-content-between"
                            style={{ width: 180 }}
                        >
                            <div className="d-flex">
                                <div style={{ width: 30 }}>
                                    <i class="fa-xl fa-duotone fa-phone-volume fa-swap-opacity"></i>
                                </div>
                                <div>
                                    <span className="ms-1 d-none d-sm-inline">Người hỗ trợ</span>
                                </div>
                            </div>
                            <div>
                                <i className="fa-solid fa-angle-right"></i>
                            </div>
                        </Nav.Link>
                    </Nav.Item>
                    <Nav.Item className="mb-2">
                        <Nav.Link
                            className="align-middle sidebar-item text-sidebar px-0 d-flex justify-content-between"
                            style={{ width: 180 }}
                        >
                            <div className="d-flex">
                                <div style={{ width: 30 }}>
                                    <i class="fa-xl fa-duotone fa-file-doc "></i>
                                </div>
                                <div>
                                    <span className="ms-1 d-none d-sm-inline">Tài liệu</span>
                                </div>
                            </div>
                            <div>
                                <i className="fa-solid fa-angle-right"></i>
                            </div>
                        </Nav.Link>
                    </Nav.Item>
                </Nav>
            </div>
        </Col>
    );
};

export default Sidebar;
