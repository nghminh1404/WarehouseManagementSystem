import React, { useState } from 'react';
import { Table, DropdownButton, Dropdown } from 'react-bootstrap';
import ModelAddSupplier from './AddSupplier';
import ModelEditSupplier from './EditSupplier';

function SupplierList() {
    const [isShowModelAddNew, setIsShowModelAddNew] = useState(false);
    const [isShowModelEdit, setIsShowModelEdit] = useState(false);

    return (
        <>
            <div className="container">
                <div className="row justify-content-center">
                    <div className="col-sm-12">
                        <h5 style={{ color: '#a5a2ad' }}>Trang chủ/Quản lý hàng hóa</h5>
                        <div className="row no-gutters my-3 d-flex justify-content-between">
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

                            <div className="col-auto ButtonCSSDropdown">
                                <button
                                    className="btn btn-success border-left-0 rounded"
                                    type="button"
                                    onClick={() => setIsShowModelAddNew(true)}
                                ><i className="fa-solid fa-plus"></i>
                                    &nbsp;
                                    Thêm nhà cung cấp

                                </button>
                            </div>
                        </div>
                        <div className=" table-responsive">
                            <Table className="table text-center table-border table-hover  border-primary table-sm">
                                <thead>
                                    <tr>
                                        <th className="align-middle   text-nowrap">STT</th>
                                        <th className="align-middle  text-nowrap">NHÀ CUNG CẤP</th>

                                        <th className="align-middle  text-nowrap">ĐỊA CHỈ</th>
                                        <th className="align-middle  text-nowrap">SỐ ĐIỆN THOẠI</th>

                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td className="align-middle text-color-primary">1</td>
                                        <td className="align-middle">Lenovo</td>
                                        <td className="align-middle">Mỹ</td>
                                        <td className="align-middle">0123456789</td>
                                        <td className="align-middle " style={{ padding: '10px' }}>

                                            <i className="fa-duotone fa-pen-to-square actionButtonCSS" onClick={() => setIsShowModelEdit(true)}></i>


                                        </td>
                                    </tr>
                                    <tr>
                                        <td className="align-middle text-color-primary">2</td>
                                        <td className="align-middle">Lenovo</td>
                                        <td className="align-middle">Mỹ</td>
                                        <td className="align-middle">0123456789</td>
                                        <td className="align-middle " style={{ padding: '10px' }}>

                                            <i className="fa-duotone fa-pen-to-square actionButtonCSS" onClick={() => setIsShowModelEdit(true)}></i>


                                        </td>
                                    </tr>
                                </tbody>
                            </Table>
                        </div>
                    </div>
                </div>
            </div>

            <ModelAddSupplier isShow={isShowModelAddNew} handleClose={() => setIsShowModelAddNew(false)} />
            <ModelEditSupplier isShow={isShowModelEdit} handleClose={() => setIsShowModelEdit(false)} />
        </>

    );
}

export default SupplierList;
