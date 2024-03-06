import React, { useEffect, useState } from 'react';
import { Table, DropdownButton, Dropdown } from 'react-bootstrap';
import ModelAddStorage from './AddStorage';
import ModelEditStorage from './EditStorage';
import { fetchAllStorages } from '~/services/StorageServices';
import ReactPaginate from 'react-paginate';

function StorageList() {
    const [isShowModelAddNew, setIsShowModelAddNew] = useState(false);
    const [isShowModelEdit, setIsShowModelEdit] = useState(false);

    const [listStorage, setListStorage] = useState([]);
    const [totalPages, setTotalPages] = useState(0);

    useEffect(() => {
        getStorages(1);
    }, [])

    const getStorages = async (page) => {
        let res = await fetchAllStorages(page);
        console.log(res.storages);
        if (res) {
            setListStorage(res.storages);
            setTotalPages(res.totalPages);
        }
    }

    const handlePageClick = (event) => {
        getStorages(+event.selected + 1);
    }

    return (
        <>
            <div className="container">
                <div className="row justify-content-center">
                    <div className="col-sm-12">
                        <h5 style={{ color: '#a5a2ad' }}>Quản lý kho hàng</h5>
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
                                    Thêm kho hàng

                                </button>
                            </div>
                        </div>
                        <div className=" table-responsive">
                            <Table className="table text-center table-border table-hover  border-primary table-sm">
                                <thead>
                                    <tr>
                                        <th className="align-middle   text-nowrap">STT</th>
                                        <th className="align-middle  text-nowrap">Kho hàng</th>

                                        <th className="align-middle  text-nowrap">ĐỊA CHỈ</th>
                                        <th className="align-middle  text-nowrap">SỐ ĐIỆN THOẠI</th>

                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody>

                                    {listStorage && listStorage.length > 0 &&
                                        listStorage.map((s, index) => (
                                            <tr key={`storage${index}`}>
                                                <td className="align-middle text-color-primary">{index + 1}</td>
                                                <td className="align-middle">{s.storageName}</td>
                                                <td className="align-middle">{s.storageAddress}</td>
                                                <td className="align-middle">0123456789</td>
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

            <ReactPaginate
                breakLabel="..."
                nextLabel="next >"
                onPageChange={handlePageClick}
                pageRangeDisplayed={5}
                pageCount={totalPages}
                previousLabel="< previous"

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

            <ModelAddStorage isShow={isShowModelAddNew} handleClose={() => setIsShowModelAddNew(false)} />
            <ModelEditStorage isShow={isShowModelEdit} handleClose={() => setIsShowModelEdit(false)} />
        </>

    );
}

export default StorageList;
