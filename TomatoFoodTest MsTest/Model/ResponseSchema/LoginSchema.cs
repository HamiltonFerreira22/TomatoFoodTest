
namespace TomatoFoodTest.Model.ResponseSchema
{
    public  class LoginSchema
    {
        public static JSchema LoginJson()
        {
            JSchema schema = JSchema.Parse(@"{
    '$schema': 'https://json-schema.org/draft-07/schema',
    'type': 'object',
    'required': [
        'success',
        'token'
    ],
    'properties': {
        'success': {
            'type': 'boolean'
        },
        'token': {
            'type': 'string'
        }
    }
}");
            return schema;
        }
    }
}
