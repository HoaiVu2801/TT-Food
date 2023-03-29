import React, { useState } from 'react';
import { Form, Input, InputNumber } from 'antd';
function index(props) {
    const layout = {
        labelCol: {
            span: 8,
        },
        wrapperCol: {
            span: 16,
        },
    };
    const validateMessages = {
        required: '${label} is required!',
    };
    const { form, onSubmit } = props;
    const onUpdate = async (data) => {
        console.log(data);
        onSubmit(data);
    };
    return (
        <>
            <Form
                {...layout}
                name="nest-messages"
                onFinish={onUpdate}
                form={form}
                style={{
                    maxWidth: 600,
                }}
                validateMessages={validateMessages}
                initialValues={{mode: 1, unitID:""}}
            >
                <Form.Item name="unitID" hidden>
                    <Input hidden />
                </Form.Item>
                <Form.Item
                    name="unitName"
                    label="Name"
                    rules={[
                        {
                            required: true,
                        },
                    ]}
                >
                    <Input />
                </Form.Item>
                <Form.Item
                    name="type"
                    label="Type"
                    rules={[
                        {
                            required: true,
                        },
                    ]}
                >
                    <Input />
                </Form.Item>
                <Form.Item
                    name="address"
                    label="Address"
                    rules={[
                        {
                            required: true,
                        }
                    ]}
                >
                    <Input />
                </Form.Item>

                <Form.Item
                    name="phoneNumber"
                    label="Phone Number"
                    rules={[
                        {
                            required: true,
                        },
                    ]}
                >
                    <Input />
                </Form.Item>
                <Form.Item name="mode" hidden>
                    <InputNumber hidden/>
                </Form.Item>
                <Form.Item
                    wrapperCol={{
                        ...layout.wrapperCol,
                        offset: 8,
                    }}
                >
                </Form.Item>
            </Form>
        </>
    );
}

export default index;