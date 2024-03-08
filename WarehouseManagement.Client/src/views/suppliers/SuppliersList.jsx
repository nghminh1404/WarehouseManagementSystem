import React, { useEffect, useState } from 'react';
import { Table, DropdownButton, Dropdown } from 'react-bootstrap';
import ModelAddSupplier from './AddSupplier';
import ModelEditSupplier from './EditSupplier';
import { fetchAllSuppliers, fetchSuppliersWithKeyword } from '~/services/SupplierServices';
import ReactPaginate from 'react-paginate';
import { toast } from 'react-toastify';


function SupplierList() {
    const [isShowModelAddNew, setIsShowModelAddNew] = useState(false);
    const [isShowModelEdit, setIsShowModelEdit] = useState(false);

    const [listSuppliers, setListSuppliers] = useState([]);
    const [totalPages, setTotalPages] = useState(5);
    const [currentPage, setcurrentPage] = useState(0);

    const [keywordSearch, setKeywordSearch] = useState("");


    useEffect(() => {
        getSuppliers(1);
    }, [])

    const getSuppliers = async (page) => {
        let res = await fetchAllSuppliers(page);
        if (res) {
            console.log(res);
            setListSuppliers(res.suppliers);
            setTotalPages(res.totalPages);
        }
    }

    const getSuppliersWithKeyword = async (page, keyword) => {
        let res = await fetchSuppliersWithKeyword(page, keyword);
        if (res) {
            console.log(res);
            setListSuppliers(res.suppliers);
            setTotalPages(res.totalPages);
        }
    }

    const handlePageClick = (event) => {
        setcurrentPage(+event.selected);
        if (keywordSearch) {
            getSuppliersWithKeyword(+event.selected + 1, keywordSearch);
        } else {
            getSuppliers(+event.selected + 1);
        }
    }

    const handleSearch = () => {
        if (keywordSearch) {
            getSuppliersWithKeyword(1, keywordSearch);
        } else {
            toast.info("Vui lòng nhập từ khóa tìm kiếm");
            getSuppliers(1);
        }
    }



    return (
        <>
            <div className="container">
                <div className="row justify-content-center">
                    <div className="col-sm-12">
                        <h5 style={{ color: '#a5a2ad' }}>Quản lý nhà cung cấp</h5>
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
                                        onChange={(event) => setKeywordSearch(event.target.value)}
                                    />
                                    <div className="input-group-append">
                                        <button
                                            className="btn btn-outline-secondary border-left-0 rounded-0 rounded-right"
                                            type="button"
                                            onClick={() => handleSearch()}
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

                                        <th className="align-middle  text-nowrap">Email</th>
                                        <th className="align-middle  text-nowrap">SỐ ĐIỆN THOẠI</th>

                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody>

                                    {listSuppliers && listSuppliers.length > 0 &&
                                        listSuppliers.map((s, index) => (
                                            <tr key={`supplier${index}`}>
                                                <td className="align-middle text-color-primary">{index + 1}</td>
                                                <td className="align-middle">{s.supplierName}</td>
                                                <td className="align-middle">{s.supplierEmail}</td>
                                                <td className="align-middle">{s.supplierPhone}</td>
                                                <td className="align-middle " style={{ padding: '10px' }}>

                                                    <i className="fa-duotone fa-pen-to-square actionButtonCSS" onClick={() => setIsShowModelEdit(true)}></i>


                                                </td>
                                            </tr>
                                        ))
                                    }



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
                    onPageChange={handlePageClick}
                    pageRangeDisplayed={5}
                    pageCount={totalPages}
                    forcePage={currentPage}
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

            <ModelAddSupplier isShow={isShowModelAddNew} handleClose={() => setIsShowModelAddNew(false)} />
            <ModelEditSupplier isShow={isShowModelEdit} handleClose={() => setIsShowModelEdit(false)} />
        </>

    );
}

export default SupplierList;
