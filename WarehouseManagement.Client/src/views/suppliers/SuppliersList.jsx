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
                        <h5 style={{ color: '#a5a2ad' }}>Quản lý nhà cung cấp</h5>
                        <div className="row no-gutters my-3 d-flex justify-content-between">
                            <div className="col-3 d-flex ">
                                <input
                                    className="form-control border-secondary border-right-0 rounded-0"
                                    type="search"
                                    defaultValue="search"
                                    id="example-search-input4"
                                    readOnly={false}
                                />

                                <button
                                    className="btn btn-outline-secondary border-left-0 rounded-0 rounded-right"
                                    type="button"
                                >
                                    <i className="fa-solid fa-magnifying-glass"></i>
                                </button>
                            </div>

                            <div className="col-6">
                                <button
                                    className="btn btn-success border-left-0 rounded"
                                    type="button"
                                    onClick={() => setIsShowModelAddNew(true)}
                                >
                                    Thêm nhà cung cấp
                                </button>
                            </div>
                        </div>
                        <div className=" table-responsive">
                            <Table className="table text-center table-border table-hover  border-primary table-sm">
                                <thead>
                                    <tr>
                                        <th className="align-middle   text-nowrap">STT</th>
                                        <th className="align-middle  text-nowrap">Nhà cung cấp</th>
                                        <th className="align-middle  text-nowrap">Địa chỉ</th>
                                        <th className="align-middle  text-nowrap">Số điện thoại</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td className="align-middle text-color-primary">1</td>
                                        <td className="align-middle">Lenovo</td>
                                        <td className="align-middle">Mỹ</td>
                                        <td className="align-middle">0398245671</td>
                                        <td><i className="fa-solid fa-pen-to-square" onClick={() => setIsShowModelEdit(true)}></i></td>
                                    </tr>

                                    <tr>
                                        <td className="align-middle text-color-primary">2</td>
                                        <td className="align-middle">Asus</td>
                                        <td className="align-middle">Mỹ</td>
                                        <td className="align-middle">012245651651</td>
                                        <td><i className="fa-solid fa-pen-to-square" onClick={() => setIsShowModelEdit(true)}></i></td>
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
