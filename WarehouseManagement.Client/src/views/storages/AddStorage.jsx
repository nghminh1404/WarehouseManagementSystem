import { useState } from "react";
import { Modal, Button } from "react-bootstrap"
import { toast } from 'react-toastify';

const ModelAddStorage = ({ isShow, handleClose }) => {
    const handleSave = () => {
        toast.success("Thêm nhà cung cấp thành công", {
            className: 'toast-success',

        });
        handleClose();
    };
    return (<>
        <Modal show={isShow} onHide={handleClose}>
            <Modal.Header closeButton>
                <Modal.Title>Thêm nhà cung cấp</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <div className="body-add-new">
                    <div className="form-group mb-3">
                        <label >Tên nhà cung cấp</label>
                        <input type="text" className="form-control inputCSS" aria-describedby="emailHelp" placeholder="Enter Name" value={"abc"} />
                    </div>
                    <div className="form-group mb-3">
                        <label >Địa chỉ</label>
                        <input type="text" className="form-control inputCSS" placeholder="Password" value={"xyz"} />
                    </div>
                    <div className="form-group mb-3">
                        <label >SĐT</label>
                        <input type="text" className="form-control inputCSS" aria-describedby="emailHelp" placeholder="Enter Name" value={"abc"} />
                    </div>


                </div>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="secondary" onClick={handleClose}>
                    Close
                </Button>
                <Button variant="primary" className="ButtonCSS" onClick={handleSave}>
                    Save Changes
                </Button>
            </Modal.Footer>
        </Modal>
    </>)
}

export default ModelAddStorage;