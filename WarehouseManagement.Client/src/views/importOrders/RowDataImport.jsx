import { useState, useEffect } from "react";
import { Row, Col, Dropdown } from "react-bootstrap";
import { fetchAllGoods } from "~/services/GoodServices";
import { fetchGoodsWithStorageAndSupplier } from "~/services/GoodServices";
import { CustomToggle, CustomMenu } from "../components/others/Dropdown";

const RowDataImportOrder = ({ onChange, selectedSupplierId, selectedStorageId }) => {
    const [costPrice, setCostPrice] = useState(0);
    const [quantity, setQuantity] = useState(0);

    const [totalGoods, setTotalGoods] = useState([]);
    const [selectedGoodCode, setSelectedGoodCode] = useState(null);
    const [selectedGoodId, setSelectedGoodId] = useState(0);


    useEffect(() => {
        getAllGoods();
    }, [])

    useEffect(() => {
        onChange({ aaa: costPrice * quantity, quantity: quantity, goodsId: selectedGoodId })
    }, [costPrice, quantity, selectedGoodId])


    const getAllGoods = async () => {
        let res = await fetchGoodsWithStorageAndSupplier(selectedStorageId, selectedSupplierId);
        setTotalGoods(res);
    }


    const handleGoodClick = (good, event) => {
        setSelectedGoodCode(good.goodsCode);
        setSelectedGoodId(good.goodsId);
    }

    const handleChangeQuantity = (event) => {
        setQuantity(event.target.value);
    }

    const handleChangePrice = (event) => {
        setCostPrice(event.target.value);
    }

    return (<Row>

        <Col md={3}>
            <label>Mã sản phẩm</label>
            <div>
                <Dropdown style={{ position: 'relative' }}>
                    <Dropdown.Toggle as={CustomToggle} id="dropdown-custom-components">
                        <span style={{ color: 'white' }}>{selectedGoodCode !== null ? selectedGoodCode : "Mã Sản phẩm"}</span>
                    </Dropdown.Toggle>

                    <Dropdown.Menu as={CustomMenu} style={{ position: 'absolute', zIndex: '9999' }}>
                        {totalGoods && totalGoods.length > 0 && totalGoods.map((g, index) => (
                            <Dropdown.Item key={`good ${index}`} eventKey={g.goodsCode} onClick={(e) => handleGoodClick(g, e)}>
                                {g.goodsCode}
                            </Dropdown.Item>
                        ))}

                        {totalGoods.length === 0 && (
                            <Dropdown.Item key="empty" disabled>
                                Không có mặt hàng
                            </Dropdown.Item>
                        )}
                    </Dropdown.Menu>
                </Dropdown>

            </div>
        </Col>

        <Col md={2}>
            <div className="form-group mb-3">
                <label >Số lượng</label>
                <input type="number" className="form-control inputCSS" value={quantity} onChange={handleChangeQuantity} />
            </div>
        </Col>
        <Col md={2}>
            <div className="form-group mb-3">
                <label >Giá tiền</label>
                <input type="number" className="form-control inputCSS" value={costPrice} onChange={handleChangePrice} />
            </div>
        </Col>



    </Row>)
}


export default RowDataImportOrder