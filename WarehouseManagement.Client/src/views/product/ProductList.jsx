import React from 'react';
import { Table } from 'react-bootstrap';

function MyTable() {
    return (
        <div className="container">
            <div className="row justify-content-center">
                <div className="col-sm-12">
                    <div className="row no-gutters">
                        <div className="col">
                            <input
                                className="form-control border-secondary border-right-0 rounded-0"
                                type="search"
                                defaultValue="search"
                                id="example-search-input4"
                                readOnly={false}
                            />
                        </div>
                        <div className="col-auto">
                            <button
                                className="btn btn-outline-secondary border-left-0 rounded-0 rounded-right"
                                type="button"
                            >
                                <i class="fa-solid fa-magnifying-glass"></i>
                            </button>
                        </div>
                    </div>
                    <h5 className="my-3" style={{ color: '#a5a2ad' }}>
                        Trang chủ/Quản lý hàng hóa
                    </h5>
                    <div className="table-responsive ">
                        <Table className="table text-center  table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th className="align-middle   text-nowrap">Mã SP</th>
                                    <th className="align-middle  text-nowrap">TÊN SẢN PHẨM</th>
                                    <th className="align-middle  text-nowrap">NHÀ CUNG CẤP</th>
                                    <th className="align-middle  text-nowrap">LOẠI</th>
                                    <th className="align-middle  text-nowrap">TỒN KHO</th>
                                    <th className="align-middle  text-nowrap">ĐƠN VỊ</th>
                                    <th className="align-middle  text-nowrap">NGÀY KHỞI TẠO</th>
                                    <th className="align-middle  text-nowrap">ORDER STATUS</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td className="text-primary align-middle">SP1</td>
                                    <td className="align-middle">OnePlues 7Pro</td>
                                    <td className="align-middle">OnePlues</td>
                                    <td className="align-middle">SmartPhone</td>
                                    <td className="align-middle">102</td>
                                    <td className="align-middle">Chiec</td>
                                    <td className="align-middle">17/02/2003</td>
                                    <td className=" text-color-primary align-middle">Đang giao dịch</td>
                                    <td className="align-middle" style={{ padding: '20px' }}>
                                        <i class="fa-duotone fa-pen-to-square"></i>
                                    </td>
                                </tr>
                                <tr>
                                    <td className="text-primary align-middle">SP2</td>
                                    <td className="align-middle">OnePlues 7Pro</td>
                                    <td className="align-middle">OnePlues</td>
                                    <td className="align-middle">SmartPhone</td>
                                    <td className="align-middle">102</td>
                                    <td className="align-middle">Chiec</td>
                                    <td className="align-middle">17/02/2003</td>
                                    <td className="text-danger align-middle">Dừng giao dịch</td>
                                    <td className="align-middle" style={{ padding: '20px' }}>
                                        <i class="fa-duotone fa-pen-to-square"></i>
                                    </td>
                                </tr>
                                <tr>
                                    <td className="text-primary align-middle">SP3</td>
                                    <td className="align-middle">OnePlues 7Pro</td>
                                    <td className="align-middle">OnePlues</td>
                                    <td className="align-middle">SmartPhone</td>
                                    <td className="align-middle">102</td>
                                    <td className="align-middle">Chiec</td>
                                    <td className="align-middle">17/02/2003</td>
                                    <td className="text-danger align-middle">Dừng giao dịch</td>
                                    <td className="align-middle" style={{ padding: '20px' }}>
                                        <i class="fa-duotone fa-pen-to-square"></i>
                                    </td>
                                </tr>
                                <tr>
                                    <td className="text-primary align-middle">SP4</td>
                                    <td className="align-middle">OnePlues 7Pro</td>
                                    <td className="align-middle">OnePlues</td>
                                    <td className="align-middle">SmartPhone</td>
                                    <td className="align-middle">102</td>
                                    <td className="align-middle">Chiec</td>
                                    <td className="align-middle">17/02/2003</td>
                                    <td className="text-color-primary align-middle">Đang giao dịch</td>
                                    <td className="align-middle" style={{ padding: '20px' }}>
                                        <i class="fa-duotone fa-pen-to-square"></i>
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
