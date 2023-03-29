import { Table, Space, Input, Button, Row, Col, notification, Modal } from 'antd';
import { PlusCircleOutlined, EditOutlined, DeleteOutlined, ExclamationCircleFilled } from '@ant-design/icons';
import { useState, useEffect } from 'react';
import Unit_Model from './UnitControl/Unit_Model';
import { unitApi } from '@/api/unitApi';

function index(props) {
    const { Search } = Input;

    const { confirm } = Modal;

    const [keyword, setKeyword] = useState("");

    const [data, setData] = useState([]);

    const getData = async () => {
        const res = await unitApi.getAll();
        setData(res.data);
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
                    const response = await unitApi.deleteUnit(id);
                    notification.open({
                        message: "Successfully",
                        description: "Deleted successfully",
                    })
                    console.log(response);
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

    const [unit, setUnit] = useState({});

    const [open, setOpen] = useState(false);

    const [isAdd, setIsAdd] = useState(false);

    const getUnit = async (id) => {
        const res = await unitApi.getUnitById(id);
        setOpen(true);
        setUnit(res.data);
        setIsAdd(false);
    }

    const onClose = () => {
        setOpen(false);
        setUnit({});
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
            dataIndex: "unitID",
            key: "unitID",
            render: (id, record, index) => index + 1,
            align: "center",
        },
        {
            title: "Name",
            dataIndex: "unitName",
            key: "unitName",
            align: "center",
        },
        {
            title: "Type",
            dataIndex: "type",
            key: "type",
            align: "center",
        },
        {
            title: "Address",
            dataIndex: "address",
            key: "address",
            align: "center",
        },
        {
            title: "Phone Number",
            dataIndex: "phoneNumber",
            key: "phonenumber",
            align: "center",
        },
        {
            title: "Action",
            key: "Action",
            align: "center",

            render: (text, record) => (
                <Space size="middle">
                    <EditOutlined onClick={() => getUnit(record.unitID)} />
                    <DeleteOutlined onClick={() => onDelete(record.unitID)} />
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
                        <a href="/">Trang chủ</a> / <a href="/food" style={{ color: 'rgb(169, 166, 166)' }}>Món ăn</a>
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
                            ? data.filter((item) => item.unitName.includes(keyword))
                            : data
                        }
                        rowKey="unitID"
                        pagination={{ defaultPageSize: 6 }}
                    />
                </Col>
            </Row>
            {open && <Unit_Model onClose={onClose} onSuccess={onSuccess} onError={onError} isAdd={isAdd} unit={unit} />}
        </div>
    );
}

export default index;