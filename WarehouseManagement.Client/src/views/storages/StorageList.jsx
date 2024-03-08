import React, { useEffect, useState } from 'react';
import { Table, DropdownButton, Dropdown } from 'react-bootstrap';
import ModelAddStorage from './AddStorage';
import ModelEditStorage from './EditStorage';
import { fetchAllStorages, fetchStoragesWithKeyword } from '~/services/StorageServices';
import ReactPaginate from 'react-paginate';

function StorageList() {
    const [isShowModelAddNew, setIsShowModelAddNew] = useState(false);
    const [isShowModelEdit, setIsShowModelEdit] = useState(false);

    const [listStorage, setListStorage] = useState([]);
    const [totalPages, setTotalPages] = useState(0);
    const [keywordSearch, setKeywordSearch] = useState("");

    const [dataUpdateStorage, setDataUpdateStorage] = useState({});
    const [currentPage, setcurrentPage] = useState();



    useEffect(() => {
        getStorages(1);
    }, [])

    const getStorages = async (page) => {
        let res = await fetchAllStorages(page);
        if (res) {
            setListStorage(res.storages);
            setTotalPages(res.totalPages);
        }
    }

    const getStoragesWithKeyword = async (page, keyword) => {
        let res = await fetchStoragesWithKeyword(page, keyword);
        if (res) {
            setListStorage(res.storages);
            setTotalPages(res.totalPages);
        }
    }

    const updateTableStorage = () => {
        if (keywordSearch) {
            getStoragesWithKeyword(currentPage + 1, keywordSearch);
        } else {
            getStorages(currentPage + 1);
        }
    }

    const showModelEditStorage = (s) => {
        setIsShowModelEdit(true);
        setDataUpdateStorage(s);

    }
    const handlePageClick = (event) => {
        setcurrentPage(+event.selected);
        if (keywordSearch) {
            getStoragesWithKeyword(+event.selected + 1, keywordSearch);
        } else {
            getStorages(+event.selected + 1);
        }


    }

    const handleSearch = async () => {
        setcurrentPage(0);
        if (keywordSearch) {
            getStoragesWithKeyword(1, keywordSearch);
        } else {
            getStorages(1);
        }
    }

    return (
        <>
            <div className="container" >
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

                                                    <i className="fa-duotone fa-pen-to-square actionButtonCSS" onClick={() => showModelEditStorage(s)}></i>


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

            <ModelAddStorage isShow={isShowModelAddNew} handleClose={() => setIsShowModelAddNew(false)} />
            <ModelEditStorage isShow={isShowModelEdit} dataUpdateStorage={dataUpdateStorage} handleClose={() => setIsShowModelEdit(false)} updateTableStorage={updateTableStorage} />
        </>

    );
}

export default StorageList;
