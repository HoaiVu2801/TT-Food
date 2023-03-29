import { SettingOutlined, UserOutlined } from '@ant-design/icons';
import { Layout, Menu, theme, Dropdown } from 'antd';
import { useState } from 'react';
import "./style.css";
const { Header, Content, Footer, Sider } = Layout;
function getItem(label, key, icon, children) {
    return {
        key,
        icon,
        children,
        label,
    };
}
const itemMenu = [
    getItem(<a style={{color:"white"}} href="/unit">Quản lý đơn vị</a>, 'sub1', <SettingOutlined />),
    getItem(<a style={{color:"white"}} href="/food">Quản lý món ăn</a>, 'sub2', <SettingOutlined />),
];
function Home(props) {
    const [collapsed, setCollapsed] = useState(false);
    const {
        token: { colorBgContainer },
    } = theme.useToken();
    return (
        <Layout
            style={{
                minHeight: '100vh',
            }}
        >
            <Sider collapsible collapsed={collapsed} onCollapse={(value) => setCollapsed(value)} width={'250px'}>
                <div className='menuIcon'>
                    <img
                        // src={}
                        style={{
                            height: 32,
                            width: 32,
                            margin: 16,
                        }}
                    />
                </div>

                <Menu
                    style={{ color: 'white' }}
                    theme="dark"
                    defaultSelectedKeys={['1']}
                    mode="inline"
                    items={itemMenu}
                />
            </Sider>
            <Layout className="site-layout">
                <Header
                    style={{
                        padding: 0,
                        background: '#001529',
                        marginBottom: '16px',
                    }}
                >
                    <div className='headerContent'>
                        <div>
                            <h1></h1>
                        </div>
                        <Dropdown>
                            <div className='itemRight'>
                                <div style={{ marginRight: '10px' }}><UserOutlined /></div>
                                <div>Admin</div>
                            </div>
                        </Dropdown>
                    </div>
                </Header>
                <Content
                    style={{
                        margin: '0 16px',
                    }}
                >
                    <div
                        style={{
                            padding: 24,
                            minHeight: 360,
                            background: colorBgContainer,
                        }}
                    >
                        {props.children}
                    </div>
                </Content>
                <Footer
                    style={{
                        textAlign: 'center',
                    }}
                >
                     ©2023 Created  
                </Footer>
            </Layout>
        </Layout>
    );
};
export default Home;