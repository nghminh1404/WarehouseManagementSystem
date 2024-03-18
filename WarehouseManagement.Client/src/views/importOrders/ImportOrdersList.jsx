import React, { useEffect, useState } from 'react';
import { Table, Form } from 'react-bootstrap';
import { removeWhiteSpace } from '~/validate';
import ReactPaginate from 'react-paginate';
import { toast } from 'react-toastify';
import ModelAddImportOrder from './AddImportOrder';


function ImportOrderList() {

    const [isShowImportModelAdd, setIsShowImportModelAdd] = useState(false);


    return (
        <>
            <div className="container">
                <div className="row justify-content-center">
                    <div className="col-sm-12">
                        <h5 style={{ color: '#a5a2ad' }}>Quản lý lô hàng nhập</h5>
                        <div className="row no-gutters my-3 d-flex justify-content-between">
                            <div className="col-2">

                            </div>
                            <div className='col'>


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
                                    onClick={() => setIsShowImportModelAdd(true)}
                                ><i className="fa-solid fa-plus"></i>
                                    &nbsp;
                                    Thêm lô hàng nhập

                                </button>
                            </div>
                        </div>
                        <div className=" table-responsive">
                            <Table className="table text-center table-border table-hover  border-primary table-sm">
                                <thead>
                                    <tr>
                                        <th className="align-middle   text-nowrap">STT</th>
                                        <th className="align-middle  text-nowrap">NHÀ CUNG CẤP</th>

                                        <th className="align-middle  text-nowrap">Email</th>
                                        <th className="align-middle  text-nowrap">SỐ ĐIỆN THOẠI</th>
                                        <th className="align-middle  text-nowrap">Tình trạng</th>


                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody>



                                </tbody>
                            </Table>
                        </div>
                    </div>
                </div>
            </div>

            <div className="d-flex justify-content-center  mt-3">
                <ReactPaginate
                    breakLabel="..."
                    nextLabel="Sau >"
                    pageRangeDisplayed={5}
                    previousLabel="< Trước"
                    pageClassName="page-item"
                    pageLinkClassName="page-link"
                    previousClassName="page-item"
                    previousLinkClassName="page-link"
                    nextClassName="page-item"
                    nextLinkClassName="page-link"
                    breakClassName="page-item"
                    breakLinkClassName="page-link"
                    containerClassName="pagination"
                    activeClassName="active"
                />
            </div>

            <ModelAddImportOrder isShow={isShowImportModelAdd} handleClose={() => setIsShowImportModelAdd(false)} />


        </>

    );
}

export default ImportOrderList;
