import React from "react";
import Button from "@mui/material/Button";
import EmergencyIcon from "@mui/icons-material/Emergency";
import "../css/ConsultationButton.css";

const ConsultationButton: React.FC = () => {
  return (
    <section className="consult-section">
      <div className="consult-text-wrap">
        <EmergencyIcon className="consult-icon" />
        <p className="consult-text">
          To ensure personalized care and the highest medical standards,
          schedule a consultation and let our experts review your case in detail
        </p>
      </div>

      <div className="consult-btn-wrap">
        <Button
          variant="contained"
          className="consult-btn"
        >
          BOOK A CONSULTATION
        </Button>
      </div>
    </section>
  );
};

export default ConsultationButton;
