import React, { useEffect, useState } from 'react';
import { Table, Form } from 'react-bootstrap';
import { removeWhiteSpace } from '~/validate';
import ReactPaginate from 'react-paginate';
import { toast } from 'react-toastify';
import ModelAddImportOrder from './AddImportOrder';
import { fetchImportOrdersWithfilter } from '~/services/ImportOrderServices';
import { formatDate, formattedAmount } from '~/validate';


function ImportOrderList() {

    const [totalImportOrder, setTotalImportOrder] = useState([]);
    const [totalPages, setTotalPages] = useState(5);
    const [currentPage, setcurrentPage] = useState(0);

    const [isShowImportModelAdd, setIsShowImportModelAdd] = useState(false);

    useEffect(() => {
        getImportOrders(1);
    }, [])
    const getImportOrders = async (page) => {
        setcurrentPage(page - 1);
        let res = await fetchImportOrdersWithfilter(page);
        setTotalImportOrder(res.data);
        setTotalPages(res.totalPages);
        console.log(res);
    }

    const handlePageClick = (event) => {
        getImportOrders(+event.selected + 1);
    }

    const updateTable = () => {
        getImportOrders(currentPage + 1);
    }



    return (
        <>
            <div className="container" style={{ maxWidth: "1600px" }}>
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
                        <div className=" table-responsive" style={{ overflowY: 'auto', overflowX: 'auto' }}>
                            <Table className="table text-center table-border table-hover  border-primary table-sm">
                                <thead>
                                    <tr>
                                        <th className="align-middle   text-nowrap">STT</th>
                                        <th className="align-middle  text-nowrap">Người tạo đơn hàng</th>
                                        <th className="align-middle  text-nowrap">NHÀ cung cấp</th>
                                        <th className="align-middle  text-nowrap">Giá trị</th>
                                        <th className="align-middle  text-nowrap">Ngày tạo đơn hàng</th>
                                        <th className="align-middle  text-nowrap">Ngày nhập hàng</th>
                                        <th className="align-middle  text-nowrap">Kho nhập hàng</th>
                                        <th className="align-middle  text-nowrap">Bên giao hàng</th>
                                        <th className="align-middle  text-nowrap">Hình ảnh</th>
                                        <th className="align-middle  text-nowrap">Tình trạng</th>
                                        <th className="align-middle  text-nowrap">Người nhận hàng</th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody>

                                    {totalImportOrder && totalImportOrder.length > 0
                                        && totalImportOrder.map((i, index) => (
                                            <tr key={`importOrder${index}`}>
                                                <td className="align-middle">{index + 1}</td>
                                                <td className="align-middle">{i.userName}</td>
                                                <td className="align-middle">{i.supplierName}</td>
                                                <td className="align-middle">{formattedAmount(i.totalCost)}</td>
                                                <td className="align-middle">{formatDate(i.createdDate)}</td>
                                                <td className="align-middle">{formatDate(i.importedDate)}</td>
                                                <td className="align-middle">{i.storageName}</td>
                                                <td className="align-middle">{i.deliveryName}</td>
                                                <td className="align-middle">{i.image}</td>
                                                <td className="align-middle">{i.statusType}</td>
                                                <td className="align-middle">{i.storekeeperName}</td>
                                                <td></td>


                                            </tr>
                                        ))}

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
                    forcePage={currentPage}
                    onPageChange={handlePageClick}
                    pageCount={totalPages}
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

            <ModelAddImportOrder isShow={isShowImportModelAdd} handleClose={() => setIsShowImportModelAdd(false)} updateTable={updateTable} />


        </>

    );
}

export default ImportOrderList;
