import React, { useEffect, useState } from 'react';
import { Table } from 'react-bootstrap';
import { fetchCategoriesWithKeyword } from '~/services/CategoryServices';
import ReactPaginate from 'react-paginate';
import { toast } from 'react-toastify';
import ModelAddCategory from './AddCategory';
import ModelEditCategory from './EditCategory';

function CategoryList() {
    const [isShowModelAddNew, setIsShowModelAddNew] = useState(false);
    const [isShowModelEdit, setIsShowModelEdit] = useState(false);


    const [listCategory, setListCategory] = useState({});
    const [totalPages, setTotalPages] = useState(5);
    const [currentPage, setCurrentPage] = useState(0);
    const [keywordSearch, setKeywordSearch] = useState("");

    const [dataUpdateCategory, setDataUpdateCategory] = useState({});


    useEffect(() => {
        getCategory(1);
        setCurrentPage(0);


    }, [])

    useEffect(() => {
        const fetchData = async () => {
            let res = await getCategory(1, keywordSearch.trim());
            if (res.data.length == 0) {
                toast.warning("Vui lòng nhập từ khóa tìm kiếm khác");
            }
        };

        fetchData();
    }, [keywordSearch])

    const getCategory = async (page, keyword) => {
        let res = await fetchCategoriesWithKeyword(page, keyword);
        console.log(res);
        if (res) {
            setListCategory(res.data);
            setTotalPages(res.totalPages);
        }
        return res;

    }

    const handlePageClick = (event) => {
        console.log(event);
        setCurrentPage(+event.selected);
        getCategory(+event.selected + 1, keywordSearch);
    }

    const updateTableCategory = () => {
        getCategory(currentPage + 1);
    }

    const showModelEditCategory = (c) => {
        setIsShowModelEdit(true);
        setDataUpdateCategory(c);
    }

    return (
        <>
            <div className="container" >
                <div className="row justify-content-center">
                    <div className="col-sm-12">
                        <h5 style={{ color: '#a5a2ad' }}>Quản lý danh mục</h5>
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
                                            disabled
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
                                    Thêm danh mục

                                </button>
                            </div>
                        </div>
                        <div className=" table-responsive">
                            <Table className="table text-center table-border table-hover  border-primary table-sm">
                                <thead>
                                    <tr>
                                        <th className="align-middle   text-nowrap">STT</th>
                                        <th className="align-middle  text-nowrap">Danh mục</th>
                                        <th className="align-middle  text-nowrap">Chi tiết</th>

                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody>

                                    {listCategory && listCategory.length > 0 &&
                                        listCategory.map((s, index) => (
                                            <tr key={`storage${index}`}>
                                                <td className="align-middle text-color-primary">{index + 1}</td>
                                                <td className="align-middle">{s.categoryName}</td>
                                                <td className="align-middle">{s.description}</td>
                                                <td className="align-middle " style={{ padding: '10px' }}>

                                                    <i className="fa-duotone fa-pen-to-square actionButtonCSS" onClick={() => showModelEditCategory(s)}></i>


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
            <ModelAddCategory isShow={isShowModelAddNew} handleClose={() => setIsShowModelAddNew(false)} updateTableCategory={updateTableCategory} />
            <ModelEditCategory isShow={isShowModelEdit} handleClose={() => setIsShowModelEdit(false)} updateTableCategory={updateTableCategory} dataUpdateCategory={dataUpdateCategory} />
        </>



    );
}

export default CategoryList;
