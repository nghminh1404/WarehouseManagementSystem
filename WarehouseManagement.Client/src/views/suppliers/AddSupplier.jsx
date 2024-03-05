import { useState } from "react";
import { Modal, Button } from "react-bootstrap"


const ModelAddSupplier = ({ isShow, handleClose }) => {

    return (<>
        <Modal show={isShow} onHide={handleClose}>
            <Modal.Header closeButton>
                <Modal.Title>Thêm nhà cung cấp</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <div className="body-add-new">
                    <div className="form-group mb-3">
                        <label >Tên nhà cung cấp</label>
                        <input type="text" className="form-control" aria-describedby="emailHelp" placeholder="Enter Name" value={"abc"} />
                    </div>
                    <div className="form-group mb-3">
                        <label >Địa chỉ</label>
                        <input type="text" className="form-control" placeholder="Password" value={"xyz"} />
                    </div>
                    <div className="form-group mb-3">
                        <label >SĐT</label>
                        <input type="text" className="form-control" aria-describedby="emailHelp" placeholder="Enter Name" value={"abc"} />
                    </div>


                </div>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="secondary" onClick={handleClose}>
                    Close
                </Button>
                <Button variant="primary">
                    Save Changes
                </Button>
            </Modal.Footer>
        </Modal>
    </>)
}

export default ModelAddSupplier;