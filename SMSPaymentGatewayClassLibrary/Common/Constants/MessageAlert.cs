
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Configuration;
using System.Web;


namespace Web.Constants
{
	[Serializable()]
	public class MessageAlert
	{
		public MessageAlert()
		{
		}


		public const string INVALID_ENTRY = "Invalid Entry.";

		public const string INVALID_DATE = "Invalid Date Range Entry.";

		public const string NUMERIC_ENTRY = "* Amount requires numeric entry.";

		public const string NUMERIC_POSITIVE = " requires positive numeric entry.";

		public const string REQUIRED_FIELD = " is required.";

		public const string USER_EXIST = "User already exists.";

        public const string PASSWORD_INVALID = "Password must be between 8 and 20 characters. Password must contain at least one digit ('0'-'9'). Passwords must have at least one uppercase ('A'-'Z'). Password must have one special character (_!@#$%.)";

		public const string PASSWORD_CHANGED = "Password successfully changed.";

		public const string PASSWORD_NOT_CHANGED = "Error in saving new password.";

		public const string PASSWORD_NOT_MATCHED = "Password does not match.";

		public const string OLD_PASSWORD_NOT_MATCHED = "The old password you typed does not match the one stored in the database.";

		public const string POSITIVE_WHOLE_NUMBER = "Numeric is positive number only";

		public const string ACTION_GENERAL_ERROR = "Error in Action Class.";

		public const string ADD_GENERAL_ERROR = "Record Creation Failed.";

		public const string CONCURRENT_ACCESS = "User has already logged in.";

		public const string DELETE_GENERAL_ERROR = "An Error occurred while deleting the record.";

		public const string DUPLICATE_ERROR = "Error in saving record. Duplicate record found.";

		public const string DUPLICATE_SUBMITTED = "This transaction has already been submitted. Record not saved.";

		public const string NO_RECORD_FOUND = "No records found.";

		public const string EDIT_GENERAL_ERROR = "An error occurred while modifying the record.";

		public const string INVALID_LOGIN = "Invalid User Credentials.";

		public const string PASSWORD_EXPIRED = "Password has expired. Please contact your System Administrator.";

		public const string MAXIMUM_INVALID_LOGIN_ATTEMPTS = "User has exceeded the maximum number of invalid login attempts." + "User has been LOCKED.";

		public const string SEARCH_GENERAL_ERROR = "An error occurred while searching.";

		public const string USER_NOT_FOUND = "User ID does not exist.";

		public const string CONFIRM_SAVE_RECORD = "Are you sure you want to save this record?";

		public const string CONFIRM_DELETE_RECORD = "Are you sure you want to delete this record?";

		public const string CONFIRM_ADDNEW_RECORD = "Are you sure you want to add a new record? ";

		public const string CONFIRM_CLEAR_RECORD = "Are you sure you want to clear all fields?";

		public const string CONFIRM_CLOSE = "Are you sure you want to disregard changes?";

		public const string CONFIRM_DISREGARD_CHANGES = "Disregard changes and continue to next screen?";

		public const string CONFIRM_GOTO_SEARCH = "Are you sure you want to go to search screen? ";

		public const string CONFIRM_CLOSE_SCREEN = "Are you sure you want to close the screen? ";

		public const string ALERT_ADD = "Record successfully added.";

		public const string ALERT_EDIT = "Record successfully edited.";

		public const string ALERT_DELETE = "Record successfully deleted.";

		public const string ALERT_SAVED = "Record successfully saved.";

		public const string ALERT_PROCESSED = "Record successfully processed.";

		public const string ALERT_ALREADY_SUBMITTED = "Record already submitted.";

		public const string NO_SEARCH_CRITERIA = "At least 1 search field is required.";

		public const string NO_PROCESS_SELECTED = "No process is selected.";

		public const string NO_RECORD_TO_PROCESS = "No record to process.";

		public const string NO_RECORD_TO_DELETE = "No record to delete.";

		public const string PAGE_GENERAL_ERROR = "Error in page.";

		public const string PARSING_GENERAL_ERROR = "Error in page.";

		public const string RECORD_SAVED = "Record saved.";

		public const string RECORD_SAVE_FAILED = "Failed to save record.";

		public const string RECORD_PARSE_SAVED = "Record successfully saved.";

		public const string RECORD_UPDATED = "Record updated.";

		public const string RECORD_UPDATE_FAILED = "Record update failed.";

		public const string RECORD_APPROVED = "Record approved.";

		public const string RECORD_APPROVE_FAILED = "Record approval failed.";

		public const string RECORD_DISAPPROVED = "Record disapproved.";

		public const string RECORD_DISAPPROVE_FAILED = "Record disapproval failed.";

		public const string CONTINUE_YES_NO = "Do you wish to continue?";

		public const string STATUS = "You are no longer authorized to logon in the system. Please contact your System Administrator.";

		public const string FILE_SUCCESSFULLY_CREATED = "File successfully created.";

		public const string REQUIRED_FIELDS_INCOMPLETE = "Please completely fill up required fields.";

		public const string UNAUTHORIZED_NETWORK = "User tried to login from an unauthorized computer and/or network";

		public const string FIRST_NAME_REQUIRED = "* First name is required.";

		public const string LAST_NAME_REQUIRED = "* Last name is required.";

		public const string ADDRESS_REQUIRED = "* Address is required.";

		public const string MOBILE_NUMBER_REQUIRED = "* Mobile number is required.";

		public const string PAYMENT_AMOUNT_REQUIRED = "* Payment amount is required.";

		public const string PAYMENT_DESCRIPTION_REQUIRED = "* Payment description is required.";

		public const string EMAIL_ADDRESS_REQUIRED = "* Email address is required.";

		public const string EMAIL_UNVERIFIED = "You have not yet verified your email adddress.";

		public const string EMAIL_FAILED_VERIFICATION = "Verification of your email address has failed or verification code has expired";

		public const string EMAIL_VERIFICATION_EXPIRED = "Your email verification code has expired.";

		public const string EMAIL_VERIFIED = "You have successfully verified your email adddress.";

		public const string EMAIL_VERIFICATION_SENT = "A verification email has been sent to ";

		public const string EMAIL_SENT = "Email successfully sent.";

		public const string EMAIL_ALREADY_EXISTS = "Email address already exists.";

		public const string EMAIL_INVALID = "Invalid email address.";

		public const string MOBILE_INVALID = "Invalid mobile number.";

		public const string REGISTRATION_SUCCESSFUL = "Registration Successful. ";

		public const string TNC_NOT_ACCEPTED = "* You have not accepted the Terms and Conditions.";

		public const string AUTHENTICATION_FAILED = "Authentication of your code has failed.";

		public const string AUTHENTICATION_CODE_EXPIRED = "Your authentication code has expired.";

		public const string PAYMENT_REFERENCE_NUMBER_REQUIRED = "* Payment reference number is required.";

		public const string PAYMENT_REFERENCE_NUMBER_NOT_EXIST = "Payment reference number does not exist.";

		public const string PAYMENT_ORDER_SUCCESSFUL = "Payment of order is successful.";

		public const string PAYMENT_ORDER_FAILED = "Payment of order failed.";

        public const string PAYMENT_FUNDING_SUCCESSFUL = "Payment of funding is successful.";

        public const string PAYMENT_FUNDING_FAILED = "Payment of funding failed.";

		public const string INVALID_SELLER_CUSTOMER_ID = "Seller ID does not exist.";

		public const string INVALID_PAYEE_ID = "Payee Customer ID does not exist.";

        public const string DELIVERY_PROVIDER_REQUIRED = "Delivery service provider is required.";

        public const string TRACKING_NUMBER_REQUIRED = "Tracking number is required.";

        public const string DATE_SENT_REQUIRED = "Date sent is required.";

        public const string ESTIMATED_DATE_OF_DELIVERY_REQUIRED = "Estimated date of delivery is required.";
	}
}

