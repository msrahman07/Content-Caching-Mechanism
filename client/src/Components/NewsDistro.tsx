import React, { useEffect, useState } from 'react'
import { Row, Col, Container } from 'react-bootstrap'
import { News } from './news';
import axios from 'axios';
import NewsList from './NewsList';

const NewsDistro = () => {
    const [currentNews, setCurrentNews] = useState<News[]>([]);
    const [popularNews, setpopularNews] = useState<News[]>([]);
    const [recentlyViewedNews, setrecentlyViewedNews] = useState<News[]>([]);
    const [refresh, setRefresh] = useState(true);

    useEffect(() => {
        axios
            .get('/api/news')
            .then((res) => {
                // console.log(res.data['result'][0]['tasks']);
                setCurrentNews((prev) => [...res.data]);
            })
            .catch((err) => {
                console.log(err);
            });
    }, []);

    useEffect(() => {
        if (refresh) {
            axios
                .get('/api/news/popular')
                .then((res) => {
                    // console.log(res.data['result'][0]['tasks']);
                    setpopularNews((prev) => [...res.data]);
                })
                .catch((err) => {
                    console.log(err);
                });
            axios
                .get('/api/news/recentlyviewed')
                .then((res) => {
                    // console.log(res.data['result'][0]['tasks']);
                    setrecentlyViewedNews((prev) => [...res.data]);
                })
                .catch((err) => {
                    console.log(err);
                });
            setRefresh(false);
        }
    }, [refresh]);

    return (
        <div className='custom-container'>
            <header>
                <h2>News Distribution</h2>
                <hr />
                <Row>
                    <Col sm="6">
                        <h4>Current News</h4>
                        <hr />
                        <NewsList newsList={currentNews} onModalClose={() => setRefresh(true)} />
                    </Col>
                    <Col sm="3" style={{ borderLeft: "1px solid", paddingLeft: "20px" }}>
                            <h4>
                                Recently Viewed
                            </h4>
                            <hr />
                            <NewsList newsList={recentlyViewedNews} onModalClose={() => setRefresh(true)} />
                        </Col>
                    <Col sm="3" style={{ borderLeft: "1px solid", paddingLeft: "20px" }}>

                            <h4>
                                Most Viewed
                            </h4>
                            <hr />
                            <NewsList newsList={popularNews} onModalClose={() => setRefresh(true)} />
                    </Col>
                </Row>
            </header>
        </div>
    )
}

export default NewsDistro