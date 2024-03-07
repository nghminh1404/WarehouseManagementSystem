import React from 'react';
import { Table, DropdownButton, Dropdown } from 'react-bootstrap';

function MyTable() {
    return (
        <div className="container">
            <div className="row justify-content-center">
                <div className="col-sm-12">
                    <h5 style={{ color: '#a5a2ad' }}>Trang chủ/Quản lý hàng hóa</h5>
                    <div className="row no-gutters my-3 ">
                        <div className="col">
                            <DropdownButton className="ButtonCSSDropdown" title={<span><i className="fa-duotone fa-warehouse"></i> Kho</span>} variant="success">
                                <Dropdown.Item href="#">Hà Nội</Dropdown.Item>
                                <Dropdown.Item href="#">Hải Phòng</Dropdown.Item>
                            </DropdownButton>
                        </div>

                        <div className="col">

                        </div>
                        <div className="col">
                            <div className="input-group">
                                <input
                                    className="form-control border-secondary inputCSS"
                                    type="search"
                                    placeholder='Tìm kiếm...'
                                    id="example-search-input4"
                                    readOnly={false}
                                />
                                <div className="input-group-append">
                                    <button
                                        className="btn btn-outline-secondary border-left-0 rounded-0 rounded-right"
                                        type="button"
                                    >
                                        <i className="fa-solid fa-magnifying-glass"></i>
                                    </button>
                                </div>
                            </div>
                        </div>
                        <div className="col-auto">
                            <a href="/AddProduct" className='ButtonCSSDropdown'>
                                <button
                                    className="btn btn-success border-left-0 rounded ButtonCSS"
                                    type="button"
                                ><i className="fa-solid fa-plus"></i>
                                    &nbsp;Thêm hàng hóa
                                </button>
                            </a>
                        </div>
                    </div>

                    <div className=" table-responsive">
                        <Table className="table text-center table-border table-hover  border-primary table-sm ">
                            <thead>
                                <tr>
                                    <th className="align-middle   text-nowrap">Mã SP</th>
                                    <th className="align-middle textColor text-nowrap">TÊN SẢN PHẨM</th>
                                    <th className="align-middle  text-nowrap">
                                        <DropdownButton className="DropdownButtonCSS" title="NHÀ CUNG CẤP" variant="success" >

                                            <Dropdown.Item href="#">HTML</Dropdown.Item>
                                            <Dropdown.Item href="#">CSS</Dropdown.Item>
                                            <Dropdown.Item href="#">JavaScript</Dropdown.Item>
                                        </DropdownButton>
                                    </th>
                                    <th className="align-middle  text-nowrap">
                                        <DropdownButton className="DropdownButtonCSS" title="THỂ LOẠI" variant="success">
                                            <Dropdown.Item href="#">HTML</Dropdown.Item>
                                            <Dropdown.Item href="#">CSS</Dropdown.Item>
                                            <Dropdown.Item href="#">JavaScript</Dropdown.Item>
                                        </DropdownButton>
                                    </th>
                                    <th className="align-middle  text-nowrap">TỒN KHO</th>
                                    <th className="align-middle  text-nowrap">ĐƠN VỊ</th>
                                    <th className="align-middle  text-nowrap">NGÀY KHỞI TẠO</th>
                                    <th className="align-middle  text-nowrap">ORDER STATUS</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td className="align-middle text-color-primary">SP1</td>
                                    <td className="align-middle">OnePlues 7Pro</td>
                                    <td className="align-middle">OnePlues</td>
                                    <td className="align-middle">SmartPhone</td>
                                    <td className="align-middle">102</td>
                                    <td className="align-middle">Chiec</td>
                                    <td className="align-middle">17/02/2003</td>
                                    <td className=" align-middle">
                                        <div className="rounded-status">
                                            <span className="rounded-status-text">Đang giao dịch</span>
                                        </div>
                                    </td>
                                    <td className="align-middle " style={{ padding: '10px' }}>
                                        <a href="/EditProduct" className='' >
                                            <i className="fa-duotone fa-pen-to-square actionButtonCSS" ></i>
                                        </a>
                                        &nbsp;
                                        <a href="/DeleteProduct">
                                            <i className="fa-duotone fa-trash-alt actionButtonCSS" ></i>
                                        </a>
                                    </td>
                                </tr>
                                <tr>
                                    <td className="align-middle text-color-primary">SP2</td>
                                    <td className="align-middle">OnePlues 7Pro</td>
                                    <td className="align-middle">OnePlues</td>
                                    <td className="align-middle">SmartPhone</td>
                                    <td className="align-middle">102</td>
                                    <td className="align-middle">Chiec</td>
                                    <td className="align-middle">17/02/2003</td>
                                    <td className="text-danger align-middle">
                                        <div className="rounded-status-stop">
                                            <span className="rounded-status-stop-text">Dừng giao dịch</span>
                                        </div>
                                    </td>
                                    <td className="align-middle " style={{ padding: '10px' }}>
                                        <a href="/EditProduct" className='' >
                                            <i className="fa-duotone fa-pen-to-square actionButtonCSS" ></i>
                                        </a>
                                        &nbsp;
                                        <a href="/DeleteProduct">
                                            <i className="fa-duotone fa-trash-alt actionButtonCSS" ></i>
                                        </a>
                                    </td>
                                </tr>
                            </tbody>
                        </Table>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default MyTable;
