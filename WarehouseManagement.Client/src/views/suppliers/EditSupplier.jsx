import { useEffect, useState } from "react";
import { Modal, Button } from "react-bootstrap"
import { toast } from 'react-toastify';
import { updateSupplier } from "~/services/SupplierServices";
import { validateEmail, validatePhone, validateText, validateTextRequired } from "~/validate";


const ModelEditSupplier = ({ isShow, handleClose, dataUpdateSupplier, updateTableSupplier }) => {

    const [nameSupplier, setNameSupplier] = useState("");
    const [phoneSupplier, setPhoneSupplier] = useState("");
    const [emailSupplier, setEmailSupplier] = useState("");
    const [noteSupplier, setNoteSupplier] = useState("");

    useEffect(() => {
        setNameSupplier(dataUpdateSupplier.supplierName);
        setPhoneSupplier(dataUpdateSupplier.supplierPhone);
        setEmailSupplier(dataUpdateSupplier.supplierEmail);
        setNoteSupplier(dataUpdateSupplier.note);
    }, [dataUpdateSupplier])

    const handleSave = async () => {
        if (!validateTextRequired.test(nameSupplier)) {
            toast.error("Tên nhà cung cấp không được để trống hoặc chứa ký tự đặc biệt");
        } else if (!validatePhone.test(phoneSupplier)) {
            toast.error("Sai định dạng số điện thoại");
        } else if (!validateEmail.test(emailSupplier)) {
            toast.error("Sai định dạng email");
        } else if (!validateText.test(noteSupplier)) {
            toast.error("Lưu ý không được chứa ký tự đặc biệt");
        } else {
            let res = await updateSupplier(dataUpdateSupplier.supplierId, nameSupplier, phoneSupplier, 1, emailSupplier, noteSupplier);
            if (res) {
                toast.success("Sửa thông tin nhà cung cấp thành công", {
                    className: 'toast-success',
                });
            }
            updateTableSupplier();
            handleCloseModal();
        }
    }

    const handleCloseModal = () => {
        handleReset();
        handleClose();
    }

    const handleReset = () => {
        setNameSupplier(dataUpdateSupplier.supplierName);
        setPhoneSupplier(dataUpdateSupplier.supplierPhone);
        setEmailSupplier(dataUpdateSupplier.supplierEmail);
        setNoteSupplier(dataUpdateSupplier.note);
    }

    return (<>
        <Modal show={isShow} onHide={handleCloseModal}>
            <Modal.Header closeButton>
                <Modal.Title>Sửa thông tin nhà cung cấp</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <div className="body-add-new">
                    <div className="form-group mb-3">
                        <label >Tên nhà cung cấp</label>
                        <input type="text" className="form-control inputCSS" aria-describedby="emailHelp" value={nameSupplier} onChange={(event) => setNameSupplier(event.target.value)} />
                    </div>
                    <div className="form-group mb-3">
                        <label >Số điện thoại</label>
                        <input type="text" className="form-control inputCSS" value={phoneSupplier} onChange={(event) => setPhoneSupplier(event.target.value)} />
                    </div>
                    <div className="form-group mb-3">
                        <label >Email</label>
                        <input type="text" className="form-control inputCSS" aria-describedby="emailHelp" value={emailSupplier} onChange={(event) => setEmailSupplier(event.target.value)} />
                    </div>
                    <div className="form-group mb-3">
                        <label >Lưu ý</label>
                        <input type="text" className="form-control inputCSS" aria-describedby="emailHelp" value={noteSupplier} onChange={(event) => setNoteSupplier(event.target.value)} />
                    </div>


                </div>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="secondary" onClick={handleReset}>
                    Xóa thông tin thay đổi
                </Button>
                <Button variant="secondary" onClick={handleCloseModal}>
                    Đóng
                </Button>
                <Button variant="primary" className="ButtonCSS" onClick={handleSave}>
                    Lưu thay đổi
                </Button>
            </Modal.Footer>
        </Modal>
    </>)
}

export default ModelEditSupplier;