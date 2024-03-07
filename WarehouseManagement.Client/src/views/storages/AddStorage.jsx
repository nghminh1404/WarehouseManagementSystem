import { useState } from "react";
import { Modal, Button } from "react-bootstrap"
import { toast } from 'react-toastify';
import { createNewStorage } from "~/services/StorageServices";

const ModelAddStorage = ({ isShow, handleClose }) => {
    const [storageName, setStorageName] = useState("");
    const [storageAddress, setStorageAddress] = useState("");

    const handleSave = async () => {
        let res = await createNewStorage(storageName, storageAddress);
        console.log(res);
        toast.success("Thêm kho hàng", {
            className: 'toast-success',

        });
        handleClose();
    };

    return (<>
        <Modal show={isShow} onHide={handleClose}>
            <Modal.Header closeButton>
                <Modal.Title>Thêm kho hàng</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <div className="body-add-new">
                    <div className="form-group mb-3">
                        <label >Tên Kho hàng</label>
                        <input type="text" className="form-control inputCSS" aria-describedby="emailHelp" placeholder="Enter Name" value={storageName} onChange={(event) => setStorageName(event.target.value)} />
                    </div>
                    <div className="form-group mb-3">
                        <label >Địa chỉ</label>
                        <input type="text" className="form-control inputCSS" placeholder="Password" value={storageAddress} onChange={(event) => setStorageAddress(event.target.value)} />
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