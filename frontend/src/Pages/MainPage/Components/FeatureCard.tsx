import React from "react";
import "../css/FeatureCard.css";

type FeatureCardProps = {
  icon: React.ReactNode;
  title: string;
  text: string;
};

const FeatureCard: React.FC<FeatureCardProps> = ({ icon, title, text }) => {
  return (
    <div className="feature-card">
      <div className="feature-icon">{icon}</div>
      <h4 className="feature-title">{title}</h4>
      <p className="feature-text">{text}</p>
    </div>
  );
};

export default FeatureCard;
