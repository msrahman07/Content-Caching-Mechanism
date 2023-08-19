import React, { useState } from 'react'
import { News } from './news'
import ViewNewsArticle from './ViewNewsArticle';

interface props {
    newsList: News[],
    onModalClose: () => void;
}

const NewsList = ({ newsList,onModalClose }: props) => {
    const sliceText = (txt: string) => {
        if (txt !== undefined && txt.length > 150) {
            return txt.slice(0, 150) + ".....";
        } else {
            return txt;
        }
    };

    const [showModal, setShowModal] = useState(false);
    const [selectedNewsId, setSelectedNewsId] = useState<number>();

    const openModal = () => {
        setShowModal(true);
    };

    return (
        <>
            {showModal && <ViewNewsArticle newsId={selectedNewsId!} closeModal={() => setShowModal(false)}  onModalClose={onModalClose} />}
            <ul>
                {newsList.map(news => (
                    <li key={news.id}>
                        <h5>
                            <div
                                style={{ color: 'blue', cursor: 'pointer' }}
                                onClick={() => {openModal(); setSelectedNewsId(news.id)}}>{news.title}</div>
                        </h5>
                        <p>
                            {sliceText(news.body)}
                        </p>
                    </li>
                ))}
            </ul>
        </>
    )
}

export default NewsList