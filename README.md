# EmailSender
Email sender is a console application designed to send an email with a dynamic template designed on SendGrid (v1).

## Usage
The following is the template for using EmailSender

```
EmailSender.exe "inputPath.csv" --to-field "email" --from-email "mymail@mail.com" --from-name "My Name" --api-key "myKey" --template-id "fdjkds9u03290"
```

The first console line argument is the path to a csv file with the emails and any other template data required for an email template. \*

Flags:

`--to-field` : The column name in the csv where the email(s) are stored. Defaults to "email".

`--from-email` : The email address that will be used as the origination point for your emails. \*

`--from-name` : The name that will be used by some email providers to identify yourself.

`--api-key` : The api key from your account on SendGrid. \*

`--template-id` : The template id of the template created in SendGrid. \*\*

\* Required
\*\* Required for version 1