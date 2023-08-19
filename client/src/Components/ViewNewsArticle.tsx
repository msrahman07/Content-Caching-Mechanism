import { useEffect, useState } from 'react';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import { News } from './news';
import axios from 'axios';

interface ViewModalProps {
    closeModal: () => void;
    newsId: number;
    onModalClose: () => void;
}

function ViewNewsArticle({ closeModal, newsId, onModalClose }: ViewModalProps) {

    const [newsArticle, setNewsArticle] = useState<News>();

    useEffect(() => {
        axios
            .get(`/api/news/${newsId}`)
            .then((res) => {
                // console.log(res.data['result'][0]['tasks']);
                setNewsArticle(res.data);
            })
            .catch((err) => {
                console.log(err);
            });
    }, [])
    const handleClose = () => {
        closeModal();
        onModalClose();
    };

    return (
        <>
            {newsArticle &&
                <Modal show={true} onHide={handleClose}>
                    <Modal.Header>
                        <Modal.Title>{newsArticle.title}</Modal.Title>
                        {/* <Modal.Title>News Title</Modal.Title> */}
                    </Modal.Header>
                    <Modal.Body>{newsArticle.body}</Modal.Body>
                    {/* <Modal.Body>News Body</Modal.Body> */}
                    <Modal.Footer>
                        <Button variant="secondary" onClick={handleClose}>
                            Close
                        </Button>
                    </Modal.Footer>
                </Modal>
            }
        </>
    );
}

export default ViewNewsArticle;