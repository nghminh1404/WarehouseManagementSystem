import { useEffect, useState } from "react";
import { Modal, Button, Col, Row } from "react-bootstrap";
import { addSuccessFullImportOrder } from "~/services/ImportOrderServices";
import { getImportOrderDetailByImportId } from "~/services/ImportOrderDetailServices";
import { toast } from 'react-toastify';

const ConfirmImportOrder = ({ isShow, handleClose, dataImportOrder }) => {
    const [totalOrderDetail, setTotalOrderDetail] = useState([]);

    useEffect(() => {
        if (dataImportOrder.importId) {
            console.log(dataImportOrder);
            getTotalOrderDetail(dataImportOrder.importId);
        }
    }, [dataImportOrder])

    const handleCloseModal = () => {
        handleClose();
    }

    const getTotalOrderDetail = async (importId) => {
        let res = await getImportOrderDetailByImportId(importId);
        console.log(res);
        setTotalOrderDetail(res);
    }

    const SaveAddImportOrder = () => {
        let res = addSuccessFullImportOrder(dataImportOrder.importId);
        toast.success("Xác nhận nhập kho thành công");
        handleClose();
    }


    return (<>
        <Modal show={isShow} onHide={handleCloseModal} size="lg">
            <Modal.Header closeButton>
                <Modal.Title>Xác nhận lô hàng nhập kho</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <div className="body-add-new">
                    <Row>
                        <Col md={2}>
                            <div className="form-group mb-3">
                                <label >Kho hàng</label>
                                <button type="button" className="btn btn-success border-left-0 rounded" disabled>{dataImportOrder.storageName}</button>
                            </div>
                        </Col>

                        <Col md={2}>
                            <div className="form-group mb-3">
                                <label >Nhà cung cấp</label>
                                <button type="button" className="btn btn-success border-left-0 rounded" disabled>{dataImportOrder.supplierName}</button>
                            </div>
                        </Col>

                        <Col md={3}>
                            <div className="form-group mb-3">
                                <label >Tổng giá trị đơn hàng</label>
                                <button type="button" className="btn btn-success border-left-0 rounded" disabled>{dataImportOrder.totalCost}</button>
                            </div>
                        </Col>
                    </Row>


                    {totalOrderDetail && totalOrderDetail.length > 0
                        && totalOrderDetail.map((o, index) => (
                            <Row key={`orderDetail${index}`}>
                                <Col md={2}>
                                    <div className="form-group mb-3">
                                        <label >Mã hàng hóa</label>
                                        <input type="number" className="form-control inputCSS" value={o.goodsId} readOnly />
                                    </div>
                                </Col>
                                <Col md={2}>
                                    <div className="form-group mb-3">
                                        <label >Số lượng</label>
                                        <input type="number" className="form-control inputCSS" value={o.quantity} readOnly />
                                    </div>
                                </Col>
                                <Col md={2}>
                                    <div className="form-group mb-3">
                                        <label >Giá tiền</label>
                                        <input type="number" className="form-control inputCSS" value={o.costPrice} readOnly />
                                    </div>
                                </Col>

                                <Col md={2}>
                                    <div className="form-group mb-3">
                                        <label >Tổng giá tiền</label>
                                        <input type="number" className="form-control inputCSS" value={o.quantity * o.costPrice} readOnly />
                                    </div>
                                </Col>
                            </Row>
                        ))
                    }

                </div>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="primary" className="ButtonCSS" onClick={SaveAddImportOrder}>
                    Xác nhận nhập kho
                </Button>
            </Modal.Footer>
        </Modal >
    </>)
}


export default ConfirmImportOrder