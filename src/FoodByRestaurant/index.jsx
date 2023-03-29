import { Table, Space, Input, Button, Row, Col, notification, Modal } from 'antd';
import { PlusCircleOutlined, EditOutlined, DeleteOutlined, ExclamationCircleFilled } from '@ant-design/icons';
import { useState, useEffect } from 'react';
import Food_Model from './FoodControl/Food_Model';
import { foodbyrestaurantApi } from '@/api/foodbyrestaurantApi';
import { format } from 'date-fns'
function index(props) {
    const { Search } = Input;

    const { confirm } = Modal;

    const [keyword, setKeyword] = useState("");

    const [data, setData] = useState([]);

    const getData = async () => {
        const res = await foodbyrestaurantApi.getAll();
        setData(res.data);
        res.data.map((item, index) => {
            let date = new Date(item.createdDate);
            let dateMDY = `${date.getDate()}-${date.getMonth() + 1}-${date.getFullYear()}`;
            item.createdDate = dateMDY;
        });
    };

    useEffect(() => {
        getData();
    }, []);

    const onDelete = async (id) => {
        confirm({
            title: "Are you sure delete this task?",
            icon: <ExclamationCircleFilled />,
            content: "Some descriptions",
            okText: "Yes",
            okType: "danger",
            cancelText: "No",
            async onOk() {
                try {
                    const response = await foodbyrestaurantApi.deleteFoodByRestaurant(id);
                    notification.open({
                        message: "Successfully",
                        description: "Deleted successfully",
                    })
                    await getData();
                } catch (error) {
                    notification.open({
                        message: "Error",
                        description: "Error deleting",
                    })
                }
            },
        });
    }

    const [food, setFood] = useState({});

    const [open, setOpen] = useState(false);

    const [isAdd, setIsAdd] = useState(false);

    const getFood = async (id) => {
        const res = await foodbyrestaurantApi.getFoodByRestaurantById(id);
        console.log(res.data);
        setOpen(true);
        setFood(res.data);
        setIsAdd(false);
    }

    const onClose = () => {
        setOpen(false);
        setFood({});
    }

    const onSuccess = async () => {
        notification.open({
            message: "Sucessfully",
            description: "Added Sucessfully",
        });
        onClose();
        await getData();
    }

    const onError = async () => {
        notification.open({
            message: "Error",
            description: "Error",
        });
        onClose();
        await getData();
    }
    const columns = [
        {
            title: "STT",
            dataIndex: "foodID",
            key: "foodID",
            render: (id, record, index) => index + 1,
            align: "center",
        },
        {
            title: "Name",
            dataIndex: "foodName",
            key: "foodName",
            align: "center",
        },
        {
            title: "Type",
            dataIndex: "type",
            key: "type",
            align: "center",
            filters: [
                {
                  text: 'Món Mặn',
                  value: 'Món Mặn',
                },
                {
                  text: 'Món Rau',
                  value: 'Món Rau',
                },
              ],
            onFilter: (value, record) => record.type.indexOf(value) === 0,
        },
        {
            title: "CreatedDate",
            dataIndex: "createdDate",
            key: "createdDate",
            align: "center",
        },
        {
            title: "UnitName",
            dataIndex: "unit",
            key: "unit",
            render: (units) => units.unitName,
            align: "center",
        },
        {
            title: "Action",
            key: "Action",
            align: "center",
            render: (text, record) => (
                <Space size="middle">
                    <EditOutlined onClick={() => getFood(record.foodID)} />
                    <DeleteOutlined onClick={() => onDelete(record.foodID)} />
                </Space>
            ),
        },
    ];
    return (
        <div>
            <Row style={{ marginBottom: "36px" }}>
                <Col span={12}>
                    <span style={{ color: "dodgerblue", fontSize: "20px", fontWeight: "bolder" }}>Danh sách món ăn</span>
                </Col>
                <Col span={12}>
                    <div style={{ float: "right" }}>
                        <a href="/food">Trang chủ</a> / <a href="/food" style={{ color: 'rgb(169, 166, 166)' }}>Món ăn</a>
                    </div>
                </Col>
            </Row>
            <Row>
                <Col span={12}>
                    <Search
                        placeholder="Search"
                        onChange={(e) => setKeyword(e.target.value)}
                        enterButton
                    />
                </Col>
                <Col span={12} style={{ float: "right" }}>
                    <div style={{ float: "right" }}>
                        <Button
                            type="primary"
                            icon={<PlusCircleOutlined />}
                            onClick={() => { setOpen(true); setIsAdd(true) }}
                        >
                            Thêm Mới
                        </Button>
                    </div>
                </Col>
            </Row>
            <Row style={{ marginTop: "36px" }}>
                <Col span={24}>
                    <Table
                        columns={columns}
                        dataSource={
                            keyword != ""
                                ? data.filter((item) => item.foodName.includes(keyword))
                                : data
                        }
                        rowKey="foodID"
                        pagination={{ defaultPageSize: 6 }}
                    />
                </Col>
            </Row>
            {open && <Food_Model onClose={onClose} onSuccess={onSuccess} onError={onError} isAdd={isAdd} food={food} />}
        </div>
    );
}

export default index;