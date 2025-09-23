import React, { useState } from "react";
import "../css/PopularServices.css";

import comprehensive from "../../../assets/services/comprehensive.jpg";
import internalImg   from "../../../assets/services/internal.jpg";
import cardio        from "../../../assets/services/cardiology.jpg";
import mental        from "../../../assets/services/mental.jpg";
import maternity     from "../../../assets/services/maternity.jpg";

type Service = {
  id: string;
  title: string;
  subtitle: string;
  image: string;
};

const services: Service[] = [
  {
    id: "comprehensive",
    title: "Comprehensive Programs",
    subtitle:
      "Integrated care for serious conditions — advanced diagnostics, surgery, and rehabilitation.",
    image: comprehensive,
  },
    {
    id: "maternity",
    title: "Maternity & Childbirth",
    subtitle:
      "Premium obstetric care with safety, comfort, and personalized support.",
    image: maternity,
  },
    {
    id: "mental",
    title: "Mental Health",
    subtitle:
      "Confidential support, therapy, and evidence-based programs.",
    image: mental,
  },
  {
    id: "internal",
    title: "Internal Medicine",
    subtitle:
      "Care for chronic and systemic diseases with long-term health management.",
    image: internalImg,
  },
  {
    id: "cardiology",
    title: "Cardiology",
    subtitle:
      "Heart care — diagnostics, prevention, and advanced treatment.",
    image: cardio,
  },
];

const PopularServices: React.FC = () => {
  const [index, setIndex] = useState(0);

  const visible = 3; // сколько карточек видно одновременно
  const total = services.length;

  const prev = () => setIndex(i => (i - 1 + total) % total);
  const next = () => setIndex(i => (i + 1) % total);

  // бесконечный срез массива
  const getVisibleServices = () => {
    const extended = [...services, ...services, ...services];
    const start = index + total; // середина
    return extended.slice(start, start + visible);
  };

  return (
    <section className="section-container ps-section" aria-labelledby="popular-services">
      <h3 id="popular-services" className="ps-title center">Popular Services</h3>

      <div className="ps-carousel">
        <button className="ps-arrow left" onClick={prev} aria-label="Previous">‹</button>

        <div className="ps-cards">
          {getVisibleServices().map(s => (
            <article key={s.id} className="ps-card">
              <img src={s.image} alt={s.title} className="ps-img" />
              <div className="ps-overlay">
                <span className="ps-label">{s.title}</span>
                <span className="ps-sub">{s.subtitle}</span>
              </div>
            </article>
          ))}
        </div>

        <button className="ps-arrow right" onClick={next} aria-label="Next">›</button>
      </div>
    </section>
  );
};

export default PopularServices;
